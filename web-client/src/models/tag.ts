export interface CreateTagDto {
  title?: string | undefined;
}

export interface Tag {
  id: string;
  creationDate: Date;
  editDate?: Date;
  userId?: string;
  title: string;
}

export interface TagDetailVm {
  id: string;
  title: string;
  creationDate: Date;
  editDate?: Date;
}

export interface TagListVm {
  tags: TagLookupDto[];
}

export interface TagLookupDto {
  id: string;
  title: string;
}

export interface UpdateTagDto {
  id: string;
  title: string;
}
