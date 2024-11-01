"use client";
import { login } from "@/app/actions/user";
import Link from "next/link";
import { useRouter } from "next/navigation";

import { z } from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";

import { useState } from "react";

const schema = z.object({
  email: z.string().email({ message: "Invalid email address" }),
  password: z
    .string()
    .min(3, { message: "Password must be at least 3 chracters long!" }),
});

const Login = () => {
  const router = useRouter();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: zodResolver(schema),
  });
  const [error, setError] = useState("");
  const onSubmit = handleSubmit(async (data) => {
    try {
      setError("");
      var res = await login(data);
      console.log(res);
      if (res.error) {
        setError(res.error?.message);
      }
      if (res.message) {
        router.push(`/`);
      }
    } catch (error: any) {
      console.log(error);
      setError("Failed to login");
    }
  });

  return (
    <div className="mt-10 max-w-md w-full mx-auto rounded-none md:rounded-2xl p-4 md:p-8 shadow-input bg-white border border-[#121212]  dark:bg-black">
      <form className="flex flex-col gap-2" onSubmit={onSubmit}>
        {error && <p className="text text-red-500">{error}</p>}
        <label htmlFor="email" className="text-sm text-gray-300">
          Email Address
        </label>
        <input
          {...register("email")}
          placeholder="abc@xyz.com"
          className="ring-[1.5px] ring-gray-300 p-2 rounded-md text-sm"
        />
        {errors.email?.message && (
          <p className="text-xs text-red-500">
            {errors.email?.message.toString()}
          </p>
        )}

        <label htmlFor="password" className="text-sm text-gray-300">
          Password
        </label>
        <input
          {...register("password")}
          placeholder="*************"
          type="password"
          className="ring-[1.5px] ring-gray-300 p-2 rounded-md text-sm"
        />
        {errors.password?.message && (
          <p className="text-xs text-red-500">
            {errors.password?.message.toString()}
          </p>
        )}

        <button type="submit" className="bg-blue-400 text-white p-2 rounded-md">
          Login &rarr;
        </button>

        <p className="text-right text-neutral-600 text-sm max-w-sm mt-4 dark:text-neutral-300">
          Don't have account? <Link href="/register">Register</Link>
        </p>
      </form>
    </div>
  );
};

export default Login;
