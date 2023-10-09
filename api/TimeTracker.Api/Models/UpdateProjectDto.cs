using AutoMapper;
using TimeTracker.Application.Common.Mappings;
using TimeTracker.Application.Projects.Commands.UpdateProject;

namespace TimeTracker.Api.Models
{
    public class UpdateProjectDto : IMapWith<UpdateProjectCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProjectDto, UpdateProjectCommand>()
                .ForMember(cmd => cmd.Title,
                    opt => opt.MapFrom(dto => dto.Title))
                .ForMember(cmd => cmd.Id,
                    opt => opt.MapFrom(dto => dto.Id));
        }
    }
}
