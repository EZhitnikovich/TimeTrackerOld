import { useEffect, FC, useContext } from "react";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "./authContext";

const LoginCallback: FC<{}> = () => {
  const context = useContext(AuthContext);
  const navigate = useNavigate();
  useEffect(() => {
    context.loginCallback().then(() => navigate("/"));
  }, [navigate]);
  return <div>Redirecting...</div>;
};

export default LoginCallback;
