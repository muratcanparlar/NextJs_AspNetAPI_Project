
import { redirect } from "next/navigation";
import { hasUserAccess, getUserInfo } from "@/utils/authHelper";
import AccessDenied from "@/components/AccessDenied";

const allowedRoles: string[] = ["admin", "teacher"];

const TeacherPage = async () => {
  try {
    const user = await getUserInfo();

    if (!user) {
      return redirect(`/login`);
    }

    const hasAccess = hasUserAccess(user, allowedRoles);
    if (!hasAccess) {
      return <AccessDenied />;
    }
    return <div>TeacherPage</div>;
  } catch (error) {
    console.error("Error fetching session:", error);
    return redirect("/login");
  }
};

export default TeacherPage;
