import { FC, ReactElement } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import AuthProvider from "./Components/auth/authContext";
import HomePage from "./Pages/HomePage";
import LogoutCallback from "./Components/auth/LogoutCallback";
import LoginCallback from "./Components/auth/LoginCallback";
import LayoutWithAuth from "./Components/LayoutWithAuth";
import LoginPage from "./Pages/LoginPage";
import Layout from "./Components/Layout";

const App: FC<{}> = (): ReactElement => {
  return (
    <AuthProvider>
      <Routes>
        <Route element={<LayoutWithAuth />}>
          <Route element={<Layout />}>
            <Route path="/" element={<HomePage />} />
            <Route path="/signout-oidc" element={<LogoutCallback />} />
            <Route path="/signin-oidc" element={<LoginCallback />} />
          </Route>
        </Route>
        <Route path="/login" element={<LoginPage />} />
      </Routes>
    </AuthProvider>
  );
};

export default App;
