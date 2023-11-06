import { User, UserManager, UserManagerSettings } from "oidc-client";
import { Constants } from "./Constants";
import { setAuthHeader } from "./AuthHeaders";

export class AuthenticationManager {
  manager: UserManager;
  user: User | null;
  constructor() {
    let settings: UserManagerSettings = {
      client_id: "time-tracker-web-api",
      redirect_uri: `${Constants.WEB_URL}/signin-oidc`,
      response_type: "code",
      scope: "openid profile TimeTrackerWebAPI",
      authority: Constants.IDENTITY_URL,
      post_logout_redirect_uri: `${Constants.WEB_URL}/signout-oidc`,
    };
    this.manager = new UserManager(settings);
    this.user = null;
  }

  isLoggedIn() {
    return this.user != null && this.user.access_token && !this.user.expired;
  }

  async loadUser() {
    await this.manager.getUser().then((user) => {
      console.log("User: ", user);
      this.user = user;
      console.log("User: ", this.user);
      const token = this.user?.access_token;
      setAuthHeader(token);
    });
  }

  signinRedirect = () => this.manager.signinRedirect();

  signinRedirectCallback = () => this.manager.signinRedirectCallback();

  signoutRedirect = (args?: any) => {
    this.manager.clearStaleState();
    this.manager.removeUser();
    return this.manager.signoutRedirect(args);
  };

  signoutRedirectCallback = () => {
    this.manager.clearStaleState();
    this.manager.removeUser();
    return this.manager.signoutRedirectCallback();
  };
}

export const authManager = new AuthenticationManager();
