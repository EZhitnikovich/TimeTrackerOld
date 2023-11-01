import { FC, ReactElement, useEffect, useRef, useState } from "react";
import { CreateTagDto, TagLookupDto } from "../../api/api";
import { FormControl } from "react-bootstrap";
import { apiClient } from "../../Helpers/ApiClient";

async function createTag(tag: CreateTagDto) {
  await apiClient.createTag(tag);
}

const TagList: FC<{}> = (): ReactElement => {
  let textInput = useRef(null);
  const [tags, setTags] = useState<TagLookupDto[] | undefined>(undefined);

  async function getTags() {
    const tagListVm = await apiClient.getAllTags();
    setTags(tagListVm.tags);
  }

  useEffect(() => {
    setTimeout(getTags, 500);
  }, []);

  const handleKeyPress = (event: React.KeyboardEvent<HTMLInputElement>) => {
    if (event.key === "Enter") {
      const tag: CreateTagDto = {
        title: event.currentTarget.value,
      };
      createTag(tag);
      event.currentTarget.value = "";
      setTimeout(getTags, 500);
    }
  };

  return (
    <div>
      tags
      <div>
        <FormControl ref={textInput} onKeyDown={handleKeyPress} />
      </div>
      <section>
        {tags?.map((tag) => (
          <div>
            {tag.title} {tag.id}
          </div>
        ))}
      </section>
    </div>
  );
};

export default TagList;
