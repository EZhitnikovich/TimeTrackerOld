import { FC, useContext, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "./authContext";

const LogoutCallback: FC<{}> = () => {
  const context = useContext(AuthContext);
  const navigate = useNavigate();
  useEffect(() => {
    context.logoutCallback().then(() => navigate("/"));
  }, [navigate]);
  return <div>Redirecting...</div>;
};

export default LogoutCallback;
