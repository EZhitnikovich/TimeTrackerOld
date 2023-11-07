import { useContext } from "react";
import { AuthContext } from "./auth/authContext";

export default function HeaderElement() {
  const authContext = useContext(AuthContext);
  return (
    <div style={{ display: "flex" }}>
      <h2>TimeTracker</h2>
      <button
        style={{ marginLeft: "auto" }}
        onClick={() => authContext.logout()}
      >
        Sign Out
      </button>
      <button
        style={{ marginLeft: "auto" }}
        onClick={() => authContext.login()}
      >
        Sign In
      </button>
    </div>
  );
}
