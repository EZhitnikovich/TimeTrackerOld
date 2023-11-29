import { Project } from "./project";
import { Tag } from "./tag";

export interface ActivityListVm {
  activities: ActivityLookupDto[];
}

export interface ActivityLookupDto {
  id: string;
  description: string;
  tags: Tag[];
  project?: Project;
  startInMilliseconds: number;
  endInMilliseconds?: number;
}

export interface CreateActivityDto {
  description: string;
  tagIds: string[];
  projectId?: string;
  startInMilliseconds: number;
  endInMilliseconds?: number;
}

export interface StartActivityDto {
  description: string;
  tagIds: string[];
  projectId?: string;
}

export interface UpdateActivityDto {
  id: string;
  description: string;
  tagIds: string[];
  projectId?: string;
  startInMilliseconds: number;
  endInMilliseconds?: number;
}
