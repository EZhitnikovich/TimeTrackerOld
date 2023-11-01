import { Client } from "../api/api";
import { Constants } from "./Constants";

export const apiClient = new Client(Constants.API_URL);
