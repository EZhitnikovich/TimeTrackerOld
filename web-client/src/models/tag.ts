export interface CreateTagDto {
  title?: string | undefined;
}

export interface Tag {
  id?: string;
  creationDate?: Date;
  editDate?: Date | undefined;
  userId?: string;
  title?: string | undefined;
}

export interface TagDetailVm {
  id?: string;
  title?: string | undefined;
  creationDate?: Date;
  editDate?: Date | undefined;
}

export interface TagListVm {
  tags?: TagLookupDto[] | undefined;
}

export interface TagLookupDto {
  id?: string;
  title?: string | undefined;
}

export interface UpdateTagDto {
  id?: string;
  title?: string | undefined;
}
