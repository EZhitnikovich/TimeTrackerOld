import { useContext } from "react";
import { AuthContext } from "../Components/auth/authContext";

export default function LoginPage() {
  const auth = useContext(AuthContext);
  return (
    <div>
      <div>Need authorization</div>
      <button onClick={() => auth.login()}>Login</button>
    </div>
  );
}
