import {
  User,
  UserManager,
  UserManagerEvents,
  UserManagerSettings,
} from "oidc-client";
import { Constants } from "./Constants";

export class AuthenticationManager {
  manager: UserManager;
  events: UserManagerEvents;
  constructor() {
    let settings: UserManagerSettings = {
      client_id: Constants.CLIENT_ID,
      redirect_uri: `${Constants.WEB_URL}/signin-oidc`,
      response_type: "code",
      scope: "openid profile TimeTrackerWebAPI",
      authority: Constants.IDENTITY_URL,
      post_logout_redirect_uri: `${Constants.WEB_URL}/signout-oidc`,
    };
    this.manager = new UserManager(settings);
    this.events = this.manager.events;
  }

  getUser() {
    return this.manager.getUser();
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
