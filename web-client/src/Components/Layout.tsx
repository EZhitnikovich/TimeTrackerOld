import { useContext } from "react";
import { AuthContext } from "./auth/authContext";
import { Outlet } from "react-router-dom";

export default function Layout() {
  const authContext = useContext(AuthContext);
  return (
    <>
      <div style={{ display: "flex" }}>
        <h2>TimeTracker</h2>
        <button
          style={{ marginLeft: "auto" }}
          onClick={() => authContext.logout()}
        >
          Sign Out
        </button>
      </div>
      <Outlet />
    </>
  );
}
