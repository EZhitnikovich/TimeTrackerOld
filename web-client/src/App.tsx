import { FC, ReactElement } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import AuthProvider from "./Components/auth/authContext";
import HomePage from "./Pages/HomePage";
import HeaderElement from "./Components/HeaderElement";
import { authManager } from "./Helpers/AuthenticationManager";
import LogoutCallback from "./Components/auth/LogoutCallback";
import LoginCallback from "./Components/auth/LoginCallback";

authManager.storeToken();

const App: FC<{}> = (): ReactElement => {
  return (
    <AuthProvider>
      <>
        <HeaderElement />
        <BrowserRouter>
          <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path="/signout-oidc" element={<LogoutCallback />} />
            <Route path="/signin-oidc" element={<LoginCallback />} />
          </Routes>
        </BrowserRouter>
      </>
    </AuthProvider>
  );
};

export default App;
