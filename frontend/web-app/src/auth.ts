import { jwtDecode } from "jwt-decode";
import NextAuth, { AuthError, CredentialsSignin } from "next-auth";
import Credentials from "next-auth/providers/credentials";

class customError extends AuthError {
  constructor(message: string) {
    super();
    this.message = message;
  }
}

async function refreshAccessToken(token: any) {
  const client_id = process.env.NEXT_PUBLIC_CLIENT_ID;
  const tokenEndpoint = process.env.NEXT_PUBLIC_TOKEN_ENDPOINT;
  const grant_type = "refresh_token";
  const reqBody = `client_id=${client_id}&grant_type=${grant_type}&refresh_token=${token.refreshToken}`;
  try {
    const response = await fetch(tokenEndpoint, {
      method: "POST",
      body: reqBody,
      headers: {
        "Content-Type": "application/x-www-form-urlencoded",
      },
    });

    const newTokens = await response.json();

    if (!response.ok) {
      throw token;
    }

    return {
      ...token,
      accessToken: newTokens.access_token,
      refreshToken: newTokens.refresh_token ?? token.refresh_token, // Fall back to old refresh token
    };
  } catch (error) {
    return {
      ...token,
      error: "RefreshAccessTokenError",
    };
  }
}

export const { handlers, signIn, signOut, auth } = NextAuth({
  providers: [
    Credentials({
      name: "Credentials",
      credentials: {
        email: { label: "Email", type: "email" },
        password: { label: "Password", type: "password" },
      },
      authorize: async (credentials) => {
        const email = credentials.email as string | undefined;
        const password = credentials.password as string | undefined;
        if (!email || !password) {
          throw new CredentialsSignin("Please provide both email & password");
        }
        const client_id = process.env.NEXT_PUBLIC_CLIENT_ID;
        const tokenEndpoint = process.env.NEXT_PUBLIC_TOKEN_ENDPOINT;

        const reqBody = `client_id=${client_id}&username=${email}&password=${password}&grant_type=password&scope=openid`;
        const res = await fetch(tokenEndpoint, {
          method: "POST",
          body: reqBody,
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
        });

        if (!res.ok) {
          const errorResult = await res.json();
          console.error(`Error: ${errorResult.error}`);
          console.error(`Error Description: ${errorResult.error_description}`);
          throw new customError(errorResult.error_description);
          //throw new Error("Invalid credentials or server error.");
          // return {
          //   error: "Invalid credentials or server error.",
          //   error_description: errorResult.error_description,
          // };
          //return null;
        }
        const parsedResponse = await res.json();
        const accessToken = parsedResponse.access_token;
        const refreshToken = parsedResponse.refresh_token;

        // Decode the access token to get user information
        const decodedToken = jwtDecode(accessToken) as any;
        //console.log(decodedToken);
        return {
          accessToken,
          refreshToken,
          role: decodedToken.realm_access.roles[0], // Adjust according to your roles structure
          name: decodedToken.preferred_username,
          email: decodedToken.email,
        };
      },
    }),
  ],
  pages: {
    signIn: "/login",
  },
  callbacks: {
    jwt: async ({ token, account, user }) => {
      if (account && user) {
        return {
          ...token,
          accessToken: user.accessToken,
          refreshToken: user.refreshToken,
          role: user.role,
          name: user.name,
          email: user.email,
        };
      }
      if (Date.now() < token.accessTokenExpires) {
        return token;
      }
      return refreshAccessToken(token);
    },
    session: async ({ session, token }) => {
      session.accessToken = token.accessToken;
      session.user = {
        name: token.name,
        email: token.email,
        role: token.role,
      };
      return session;
    },
  },
});
