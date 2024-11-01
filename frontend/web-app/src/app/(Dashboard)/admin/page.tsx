import { redirect } from "next/navigation";
import { hasUserAccess, getUserInfo } from "@/utils/authHelper";
import AccessDenied from "@/components/AccessDenied";
const allowedRoles: string[] = ["admin", "parent"];

const AdminPage = async () => {
  const user = await getUserInfo();
  if (!user) {
    return redirect(`/login`);
  }
  const hasAccess = hasUserAccess(user, allowedRoles);
  if (!hasAccess) {
    return <AccessDenied />;
  }
  return <div>AdminPage</div>;
};

export default AdminPage;
