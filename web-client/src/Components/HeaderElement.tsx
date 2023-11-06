import React, { useEffect, useRef, useState } from "react";
import { authManager } from "../Helpers/AuthenticationManager";

export default function HeaderElement() {
  return (
    <div style={{ display: "flex" }}>
      <h2>TimeTracker</h2>
      {authManager.isLoggedIn() ? (
        <button
          style={{ marginLeft: "auto" }}
          onClick={() => authManager.signoutRedirect()}
        >
          Sign Out
        </button>
      ) : (
        <button
          style={{ marginLeft: "auto" }}
          onClick={() => authManager.signinRedirect()}
        >
          Sign In
        </button>
      )}
    </div>
  );
}
