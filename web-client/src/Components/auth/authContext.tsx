import { User } from "oidc-client";
import { createContext, useState } from "react";
import { AuthenticationManager } from "../../Helpers/AuthenticationManager";
import { setAuthHeader } from "../../Helpers/AuthHeaders";

interface AuthContextType {
  user: User | null;
  login: () => Promise<void>;
  logout: () => Promise<void>;
  loginCallback: () => Promise<void>;
  logoutCallback: () => Promise<void>;
}

export const AuthContext = createContext<AuthContextType>(null!);

type AuthProviderProps = {
  children: JSX.Element;
};

function AuthProvider({ children }: AuthProviderProps) {
  const [user, setUser] = useState<User | null>(null);
  const authManager = new AuthenticationManager();

  const onUserLoaded = (user: User) => {
    console.log("User loaded: ", user);
    setAuthHeader(user.access_token);
  };
  const onUserUnloaded = () => {
    setAuthHeader(null);
    console.log("User unloaded");
  };
  const onAccessTokenExpiring = () => {
    console.log("User token expiring");
  };
  const onAccessTokenExpired = () => {
    console.log("User token expired");
  };
  const onUserSignedOut = () => {
    console.log("User signed out");
  };

  authManager.events.addUserLoaded(onUserLoaded);
  authManager.events.addUserUnloaded(onUserUnloaded);
  authManager.events.addAccessTokenExpiring(onAccessTokenExpiring);
  authManager.events.addAccessTokenExpired(onAccessTokenExpired);
  authManager.events.addUserSignedOut(onUserSignedOut);

  const loginCallback = async () => {
    const usr = await authManager.signinRedirectCallback();
    setAuthHeader(usr.access_token);
    setUser(usr);
  };

  const logoutCallback = async () => {
    await authManager.signoutRedirectCallback();
    setAuthHeader(null);
    setUser(null);
  };

  const login = () => authManager.signinRedirect();
  const logout = () =>
    authManager.signoutRedirect({
      id_token_hint: user?.id_token,
    });

  const values = { user, login, logout, loginCallback, logoutCallback };

  return <AuthContext.Provider value={values}>{children}</AuthContext.Provider>;
}

export default AuthProvider;
