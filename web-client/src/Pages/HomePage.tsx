import { useState } from "react";
import CreatableSelect from "react-select/creatable";
import { MultiValue } from "react-select";
import { timeTrackerAPI } from "../services/TimeTrackerService";

type Option = {
  label: string;
  value: string;
};

export default function HomePage() {
  // tags
  const {
    data: tagsListVm,
    error: tagsFetchError,
    isLoading: tagsFetchLoading,
  } = timeTrackerAPI.useFetchAllTagsQuery(null);
  const [createTag, {}] = timeTrackerAPI.useCreateTagMutation();
  const [updateTag, {}] = timeTrackerAPI.useUpdateTagMutation();
  const [deleteTag, {}] = timeTrackerAPI.useDeleteTagMutation();
  // projects
  const {
    data: projectsListVm,
    error: projectsFetchError,
    isLoading: projectFetchLoading,
  } = timeTrackerAPI.useFetchAllProjectsQuery(null);
  const [createProject, {}] = timeTrackerAPI.useCreateProjectMutation();
  const [updateProject, {}] = timeTrackerAPI.useUpdateProjectMutation();
  const [deleteProject, {}] = timeTrackerAPI.useDeleteProjectMutation();
  // activities
  const {
    data: activitiesListVm,
    error: activitiesFetchError,
    isLoading: activitiesFetchLoading,
  } = timeTrackerAPI.useFetchAllActivitiesQuery(null);
  const [createActivity, {}] = timeTrackerAPI.useCreateActivityMutation();
  const [updateActivity, {}] = timeTrackerAPI.useUpdateActivityMutation();
  const [deleteActivity, {}] = timeTrackerAPI.useDeleteActivityMutation();
  const [startActivity, {}] = timeTrackerAPI.useStartActivityMutation();
  const [stopActivity, {}] = timeTrackerAPI.useStopActivityMutation();

  const [selectedTagIds, setSelectedTagIds] = useState<string[] | undefined>();
  const [selectedProjectId, setSelectedProjectId] = useState<
    string | undefined
  >();

  const [description, setDescription] = useState<string>("");

  async function handleTagCreate(inputValue: string) {
    createTag({ title: inputValue });
  }

  async function handleProjectCreate(inputValue: string) {
    createProject({ title: inputValue });
  }

  const onTagSelectionChange = (newValue: MultiValue<Option>) => {
    var tags = newValue.map((x) => x.value);
    setSelectedTagIds(tags);
  };
  const onProjectSelectionChange = (newValue: Option) => {
    if (newValue === null) return;
    setSelectedProjectId(newValue.value);
  };

  const handleDescriptionInput = (elem: React.FormEvent<HTMLInputElement>) => {
    setDescription(elem.currentTarget.value);
  };

  const startActivityHandler = () => {
    startActivity({
      description: description,
      projectId: selectedProjectId,
      tagIds: selectedTagIds,
    });
  };

  return (
    <div>
      <div className="">
        <input placeholder="description" onChange={handleDescriptionInput} />
        <CreatableSelect
          isClearable={true}
          placeholder="Select project"
          onChange={(x) => onProjectSelectionChange(x as Option)}
          onCreateOption={handleProjectCreate}
          options={projectsListVm?.projects?.map(
            (x) => ({ value: x.id, label: x.title } as Option)
          )}
        />
        <CreatableSelect
          placeholder="Select tags"
          closeMenuOnSelect={false}
          isMulti={true}
          onCreateOption={handleTagCreate}
          onChange={(x) => onTagSelectionChange(x)}
          options={tagsListVm?.tags?.map(
            (x) =>
              ({
                value: x.id,
                label: x.title,
              } as Option)
          )}
        />
      </div>
      <button onClick={() => startActivityHandler()}>start</button>
      <section>
        {activitiesListVm?.activities?.map((activity) => (
          <div key={activity.id}>
            {activity.description} {activity.id} {activity.startInMilliseconds}{" "}
            {activity.endInMilliseconds}
          </div>
        ))}
      </section>
    </div>
  );
}
