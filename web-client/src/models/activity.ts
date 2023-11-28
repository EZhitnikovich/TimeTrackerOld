import { Project } from "./project";
import { Tag } from "./tag";

export interface ActivityListVm {
  activities?: ActivityLookupDto[] | undefined;
}

export interface ActivityLookupDto {
  id?: string;
  description?: string | undefined;
  tags?: Tag[] | undefined;
  project?: Project;
  startInMilliseconds?: number;
  endInMilliseconds?: number | undefined;
}

export interface CreateActivityDto {
  description?: string | undefined;
  tagIds?: string[] | undefined;
  projectId?: string | undefined;
  startInMilliseconds?: number;
  endInMilliseconds?: number | undefined;
}

export interface StartActivityDto {
  description?: string | undefined;
  tagIds?: string[] | undefined;
  projectId?: string | undefined;
}

export interface UpdateActivityDto {
  id?: string;
  description?: string | undefined;
  tagIds?: string[] | undefined;
  projectId?: string | undefined;
  startInMilliseconds?: number;
  endInMilliseconds?: number | undefined;
}
