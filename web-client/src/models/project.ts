export interface CreateProjectDto {
  title?: string | undefined;
}

export interface Project {
  id?: string;
  creationDate?: Date;
  editDate?: Date | undefined;
  userId?: string;
  title?: string | undefined;
}

export interface ProjectDetailVm {
  id?: string;
  title?: string | undefined;
  creationDate?: Date;
  editDate?: Date | undefined;
}

export interface ProjectListVm {
  projects?: ProjectLookupDto[] | undefined;
}

export interface ProjectLookupDto {
  id?: string;
  title?: string | undefined;
}

export interface UpdateProjectDto {
  id?: string;
  title?: string | undefined;
}
