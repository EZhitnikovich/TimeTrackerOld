import { FC, ReactElement } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import AuthProvider from "./Components/auth/auth-provider";
import SignInOidc from "./Components/auth/SigninOidc";
import SignOutOidc from "./Components/auth/SignoutOidc";
import HomePage from "./Pages/HomePage";
import HeaderElement from "./Components/HeaderElement";
import { authManager } from "./Helpers/AuthenticationManager";

authManager.loadUser();

const App: FC<{}> = (): ReactElement => {
  authManager.loadUser();
  console.log("app", authManager.user);
  return (
    <div>
      <HeaderElement />
      <AuthProvider userManager={authManager.manager}>
        <>
          <BrowserRouter>
            <Routes>
              <Route path="/" element={<HomePage />} />
              <Route path="/signout-oidc" element={<SignOutOidc />} />
              <Route path="/signin-oidc" element={<SignInOidc />} />
            </Routes>
          </BrowserRouter>
        </>
      </AuthProvider>
    </div>
  );
};

export default App;
