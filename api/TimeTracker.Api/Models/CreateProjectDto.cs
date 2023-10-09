using AutoMapper;
using TimeTracker.Application.Common.Mappings;
using TimeTracker.Application.Projects.Commands.CreateProject;

namespace TimeTracker.Api.Models
{
    public class CreateProjectDto : IMapWith<CreateProjectCommand>
    {
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectDto, CreateProjectCommand>()
                .ForMember(cmd => cmd.Title,
                    opt => opt.MapFrom(dto => dto.Title));
        }
    }
}
