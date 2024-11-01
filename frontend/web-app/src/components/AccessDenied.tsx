const AccessDenied = () => {
  return (
    <div className="text-center mt-5">
      <h1 className="text-red-500 text-4xl">Access Denied</h1>
      <p className="text-lg text-gray-700 mt-2">
        You don't have the necessary permissions to access this page.
      </p>
      <p className="text-lg text-gray-700 mt-2">
        Please contact the administrator if you believe this is a mistake.
      </p>
    </div>
  );
};

export default AccessDenied;
