import { combineReducers, configureStore } from "@reduxjs/toolkit";
import { timeTrackerAPI } from "../services/TimeTrackerService";

const rootReducer = combineReducers({
  [timeTrackerAPI.reducerPath]: timeTrackerAPI.reducer,
});

export const setupStore = () => {
  return configureStore({
    reducer: rootReducer,
    middleware: (getDefaultMiddleware) =>
      getDefaultMiddleware().concat(timeTrackerAPI.middleware),
  });
};

export type RootState = ReturnType<typeof rootReducer>;
export type AppStore = ReturnType<typeof setupStore>;
export type AppDispatch = AppStore["dispatch"];
