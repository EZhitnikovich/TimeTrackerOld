import { FC, ReactElement } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import userManager, {
  loadUser,
  signinRedirect,
} from "./Components/auth/user-service";
import AuthProvider from "./Components/auth/auth-provider";
import SignInOidc from "./Components/auth/SigninOidc";
import SignOutOidc from "./Components/auth/SignoutOidc";
import TagList from "./Pages/tags/TagList";
import HomePage from "./Pages/HomePage";

const App: FC<{}> = (): ReactElement => {
  loadUser();
  return (
    <div>
      <header>
        <button onClick={() => signinRedirect()}>Login</button>
        <AuthProvider userManager={userManager}>
          <BrowserRouter>
            <Routes>
              <Route path="/" element={<HomePage />} />
              <Route path="/signout-oidc" element={<SignOutOidc />} />
              <Route path="/signin-oidc" element={<SignInOidc />} />
            </Routes>
          </BrowserRouter>
        </AuthProvider>
      </header>
    </div>
  );
};

export default App;
