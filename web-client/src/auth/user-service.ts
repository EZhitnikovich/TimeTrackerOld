import { UserManager, UserManagerSettings } from "oidc-client";
import { setAuthHeader } from "./auth-headers";
import { app_consts } from "../consts";

const userManagerSettings: UserManagerSettings = {
  client_id: "time-tracker-web-api",
  redirect_uri: `${app_consts.WEB_URL}/signin-oidc`,
  response_type: "code",
  scope: "openid profile TimeTrackerWebAPI",
  authority: app_consts.IDENTITY_URL,
  post_logout_redirect_uri: `${app_consts.WEB_URL}/signout-oidc`,
};

const userManager = new UserManager(userManagerSettings);
export async function loadUser() {
  const user = await userManager.getUser();
  console.log("User: ", user);
  const token = user?.access_token;
  setAuthHeader(token);
}

export const signinRedirect = () => userManager.signinRedirect();

export const signinRedirectCallback = () =>
  userManager.signinRedirectCallback();

export const signoutRedirect = (args?: any) => {
  userManager.clearStaleState();
  userManager.removeUser();
  return userManager.signoutRedirect(args);
};

export const signoutRedirectCallback = () => {
  userManager.clearStaleState();
  userManager.removeUser();
  return userManager.signoutRedirectCallback();
};

export default userManager;
