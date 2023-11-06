import { useEffect, FC } from "react";
import { useNavigate } from "react-router-dom";
import { authManager } from "../../Helpers/AuthenticationManager";

const SigninOidc: FC<{}> = () => {
  const navigate = useNavigate();
  useEffect(() => {
    async function signinAsync() {
      await authManager.signinRedirectCallback();
      navigate("/");
      window.location.reload();
    }
    signinAsync();
  }, [navigate]);
  return <div>Redirecting...</div>;
};

export default SigninOidc;
