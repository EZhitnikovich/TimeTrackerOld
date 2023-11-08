import { useContext, useEffect } from "react";
import { AuthContext } from "./auth/authContext";
import { Outlet, useNavigate } from "react-router-dom";

type RequireAuthProps = {
  children: JSX.Element;
};

function RequireAuth({ children }: RequireAuthProps) {
  const auth = useContext(AuthContext);
  const navigate = useNavigate();
  useEffect(() => {
    if (!auth.user) navigate("/login");
  }, [auth.user, navigate]);
  return children;
}

export default function LayoutWithAuth() {
  return (
    <RequireAuth>
      <Outlet />
    </RequireAuth>
  );
}
