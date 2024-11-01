import { getSession } from "@/lib/getSession";

// Method to fetch user info
export const getUserInfo = async () => {
  try {
    const session = await getSession();
    const user = session?.user;
    return user;
  } catch (error) {
    console.error("Error fetching session:", error);
    return null;
  }
};

// Method to check user role
export const hasUserAccess = (user, allowedRoles: string[]) => {
  if (!user) {
    return false;
  }

  if (!allowedRoles.includes(user.role.toLowerCase())) {
    return false;
  }

  return true;
};
