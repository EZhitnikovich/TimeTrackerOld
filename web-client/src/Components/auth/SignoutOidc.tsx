import { FC, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { authManager } from "../../Helpers/AuthenticationManager";

const SignoutOidc: FC<{}> = () => {
  const navigate = useNavigate();
  useEffect(() => {
    const signoutAsync = async () => {
      await authManager.signoutRedirectCallback();
      navigate("/");
      window.location.reload();
    };
    signoutAsync();
  }, [navigate]);
  return <div>Redirecting...</div>;
};

export default SignoutOidc;
