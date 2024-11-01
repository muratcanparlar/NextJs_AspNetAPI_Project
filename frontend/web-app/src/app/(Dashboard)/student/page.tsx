import { redirect } from "next/navigation";
import { hasUserAccess, getUserInfo } from "@/utils/authHelper";
import AccessDenied from "@/components/AccessDenied";

const allowedRoles: string[] = ["admin", "student"];

const StudentPage = async () => {
  const user = await getUserInfo();

  if (!user) {
    return redirect(`/login`);
  }

  const hasAccess = hasUserAccess(user, allowedRoles);
  if (!hasAccess) {
    return <AccessDenied />;
  }

  return <div>StudentPage</div>;
};

export default StudentPage;
