import { useEffect, useState } from "react";
import { ActivityLookupDto, ProjectLookupDto, TagLookupDto } from "../api/api";
import { apiClient } from "../Helpers/ApiClient";
import CreatableSelect from "react-select/creatable";
import { MultiValue } from "react-select";

type Option = {
  label: string;
  value: string;
};

export default function HomePage() {
  const [activities, setActivities] = useState<ActivityLookupDto[] | undefined>(
    undefined
  );

  const [tags, setTags] = useState<TagLookupDto[] | undefined>();
  const [selectedTagIds, setSelectedTagIds] = useState<string[] | undefined>();

  const [projects, setProjects] = useState<ProjectLookupDto[] | undefined>();
  const [selectedProjectId, setSelectedProjectId] = useState<
    string | undefined
  >();

  async function getActivities() {
    const activityListVm = await apiClient.getAllActivities();
    setActivities(activityListVm.activities);
  }
  async function getTags() {
    const tagsListVm = await apiClient.getAllTags();
    setTags(tagsListVm.tags);
  }
  async function getProjects() {
    const projectListVm = await apiClient.getAllProjects();
    setProjects(projectListVm.projects);
  }

  async function handleTagCreate(inputValue: string) {
    await apiClient.createTag({ title: inputValue });
    await getTags();
  }

  async function handleProjectCreate(inputValue: string) {
    await apiClient.createProject({ title: inputValue });
    await getProjects();
  }

  useEffect(() => {
    getActivities();
    getProjects();
    getTags();
  }, []);

  const onTagSelectionChange = (newValue: MultiValue<Option>) => {
    var tags = newValue.map((x) => x.value);
    setSelectedTagIds(tags);
  };
  const onProjectSelectionChange = (newValue: Option) => {
    if (newValue === null) return;
    setSelectedProjectId(newValue.value);
  };

  return (
    <div>
      <div className="">
        <input placeholder="description" />
        <CreatableSelect
          isClearable={true}
          placeholder="Select project"
          onChange={(x) => onProjectSelectionChange(x as Option)}
          onCreateOption={handleProjectCreate}
          options={projects?.map(
            (x) => ({ value: x.id, label: x.title } as Option)
          )}
        />
        <CreatableSelect
          placeholder="Select tags"
          closeMenuOnSelect={false}
          isMulti={true}
          onCreateOption={handleTagCreate}
          onChange={(x) => onTagSelectionChange(x)}
          options={tags?.map(
            (x) =>
              ({
                value: x.id,
                label: x.title,
              } as Option)
          )}
        />
      </div>
      <button
        onClick={() =>
          apiClient.startActivity({
            description: "t",
            projectId: selectedProjectId,
            tagIds: selectedTagIds,
          })
        }
      >
        start
      </button>
      <section>
        {activities?.map((activity) => (
          <div key={activity.id}>
            {activity.description} {activity.id} {activity.startInMilliseconds}{" "}
            {activity.endInMilliseconds}
          </div>
        ))}
      </section>
    </div>
  );
}
