using AutoMapper;
using TimeTracker.Application.Common.Mappings;
using TimeTracker.Domain;

namespace TimeTracker.Application.Projects.Queries.GetProjectList
{
    public class ProjectLookupDto : IMapWith<Project>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectLookupDto>()
                .ForMember(vm => vm.Id,
                    opt => opt.MapFrom(tag => tag.Id))
                .ForMember(vm => vm.Title,
                    opt => opt.MapFrom(tag => tag.Title));
        }
    }
}
