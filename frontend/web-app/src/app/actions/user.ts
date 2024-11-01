"use server";
import { signIn } from "@/auth";

const login = async ({ email, password }) => {
  try {
    const session = await signIn("credentials", {
      redirect: false,
      callbackUrl: "/",
      email,
      password,
    });
    return { success: true, message: "login successful" };
  } catch (err: any) {
    if (err.type === "AuthError") {
      return {
        error: { message: err.message },
      };
    }
    return { error: { message: "Failed to login", error: err } };
  }
};

export { login };
