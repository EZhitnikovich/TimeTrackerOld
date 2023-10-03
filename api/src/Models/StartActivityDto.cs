using AutoMapper;
using TimeTracker.Application.Activities.Commands.StartActivity;
using TimeTracker.Application.Common.Mappings;

namespace TimeTrackerApi.Models
{
    public class StartActivityDto : IMapWith<StartActivityCommand>
    {
        public string Description { get; set; }
        public List<Guid> TagIds { get; set; }
        public Guid? ProjectId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StartActivityDto, StartActivityCommand>()
                .ForMember(cmd => cmd.Description,
                    opt => opt.MapFrom(dto => dto.Description))
                .ForMember(cmd => cmd.TagIds,
                    opt => opt.MapFrom(dto => dto.TagIds))
                .ForMember(cmd => cmd.ProjectId,
                    opt => opt.MapFrom(dto => dto.ProjectId));
        }
    }
}
