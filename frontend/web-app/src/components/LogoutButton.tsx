"use client";

import { signOut } from "next-auth/react";
import Image from "next/image";

const LogoutButton = () => {
  const handleLogout = async () => {
    await signOut({ callbackUrl: "/login" });
  };

  return (
    <button
      onClick={handleLogout}
      className="flex items-center justify-center lg:justify-start gap-4 text-gray-500 py-2"
    >
      <Image src="/logout.png" alt="Logout" width={20} height={20} />
      <span className="hidden lg:block">Logout</span>
    </button>
  );
};

export default LogoutButton;
