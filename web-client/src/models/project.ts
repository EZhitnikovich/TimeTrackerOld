export interface CreateProjectDto {
  title?: string | undefined;
}

export interface Project {
  id: string;
  creationDate: Date;
  editDate?: Date;
  userId?: string;
  title: string;
}

export interface ProjectDetailVm {
  id: string;
  title: string;
  creationDate: Date;
  editDate?: Date;
}

export interface ProjectListVm {
  projects: ProjectLookupDto[];
}

export interface ProjectLookupDto {
  id: string;
  title: string;
}

export interface UpdateProjectDto {
  id: string;
  title: string;
}
