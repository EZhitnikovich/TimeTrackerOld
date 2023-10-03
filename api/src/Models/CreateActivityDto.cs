using AutoMapper;
using TimeTracker.Application.Activities.Commands.CreateActivity;
using TimeTracker.Application.Common.Mappings;
using TimeTracker.Domain;

namespace TimeTrackerApi.Models
{
    public class CreateActivityDto : IMapWith<CreateActivityCommand>
    {
        public string Description { get; set; }
        public List<Guid> TagIds { get; set; }
        public Guid? ProjectId { get; set; }
        public long StartInMilliseconds { get; set; }
        public long? EndInMilliseconds { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateActivityDto, CreateActivityCommand>()
                .ForMember(cmd => cmd.Description,
                    opt => opt.MapFrom(dto => dto.Description))
                .ForMember(cmd => cmd.TagIds,
                    opt => opt.MapFrom(dto => dto.TagIds))
                .ForMember(cmd => cmd.ProjectId,
                    opt => opt.MapFrom(dto => dto.ProjectId))
                .ForMember(cmd => cmd.StartInMilliseconds,
                    opt => opt.MapFrom(dto => dto.StartInMilliseconds))
                .ForMember(cmd => cmd.EndInMilliseconds,
                    opt => opt.MapFrom(dto => dto.EndInMilliseconds));
        }
    }
}
