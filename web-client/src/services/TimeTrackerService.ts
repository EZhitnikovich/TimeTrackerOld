import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/dist/query/react";
import { Constants } from "../Helpers/Constants";
import { CreateTagDto, TagListVm, UpdateTagDto } from "../models/tag";
import {
  ProjectListVm,
  UpdateProjectDto,
  CreateProjectDto,
} from "../models/project";
import {
  ActivityListVm,
  CreateActivityDto,
  StartActivityDto,
  UpdateActivityDto,
} from "../models/activity";

export const timeTrackerAPI = createApi({
  reducerPath: "tagAPI",
  baseQuery: fetchBaseQuery({
    baseUrl: `${Constants.API_URL}/api`,
    prepareHeaders: (headers) => {
      const token = localStorage.getItem("token");
      if (token) {
        headers.set("Authorization", `Bearer ${token}`);
      }
      return headers;
    },
  }),
  tagTypes: ["Tag", "Activity", "Project"],
  endpoints: (build) => ({
    // tags
    fetchAllTags: build.query<TagListVm, null>({
      query: () => ({
        url: "/Tags/GetAll",
      }),
      providesTags: ["Tag"],
    }),
    createTag: build.mutation<string, CreateTagDto>({
      query: (tag) => ({
        url: "/Tags/Create",
        method: "POST",
        body: tag,
      }),
      invalidatesTags: ["Tag"],
    }),
    updateTag: build.mutation<null, UpdateTagDto>({
      query: (tag) => ({
        url: "/Tags/Update",
        method: "PUT",
        body: tag,
      }),
      invalidatesTags: ["Tag"],
    }),
    deleteTag: build.mutation<null, string>({
      query: (id) => ({
        url: `/Tags/Delete?id=${id}`,
        method: "DELETE",
      }),
    }),
    // projects
    fetchAllProjects: build.query<ProjectListVm, null>({
      query: () => ({
        url: "/Project/GetAll",
      }),
      providesTags: ["Project"],
    }),
    createProject: build.mutation<string, CreateProjectDto>({
      query: (project) => ({
        url: "/Project/Create",
        method: "POST",
        body: project,
      }),
      invalidatesTags: ["Project"],
    }),
    updateProject: build.mutation<null, UpdateProjectDto>({
      query: (project) => ({
        url: "/Project/Update",
        method: "PUT",
        body: project,
      }),
      invalidatesTags: ["Project"],
    }),
    deleteProject: build.mutation<null, string>({
      query: (id) => ({
        url: `/Project/Delete?id=${id}`,
        method: "DELETE",
      }),
      invalidatesTags: ["Project"],
    }),
    // activities
    fetchAllActivities: build.query<ActivityListVm, null>({
      query: () => ({
        url: "/Activity/GetAll",
      }),
      providesTags: ["Activity"],
    }),
    createActivity: build.mutation<string, CreateActivityDto>({
      query: (activity) => ({
        url: "/Activity/Create",
        method: "POST",
        body: activity,
      }),
      invalidatesTags: ["Activity"],
    }),
    updateActivity: build.mutation<null, UpdateActivityDto>({
      query: (activity) => ({
        url: "/Activity/Update",
        method: "PUT",
        body: activity,
      }),
      invalidatesTags: ["Activity"],
    }),
    deleteActivity: build.mutation<null, string>({
      query: (id) => ({
        url: `/Activity/Delete?id=${id}`,
        method: "DELETE",
      }),
      invalidatesTags: ["Activity"],
    }),
    startActivity: build.mutation<string, StartActivityDto>({
      query: (activity) => ({
        url: "/Activity/Start",
        method: "POST",
        body: activity,
      }),
      invalidatesTags: ["Activity"],
    }),
    stopActivity: build.mutation<null, string>({
      query: (id) => ({
        url: `/Activity/Stop?id=${id}`,
        method: "PUT",
      }),
      invalidatesTags: ["Activity"],
    }),
  }),
});
