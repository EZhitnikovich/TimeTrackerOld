using AutoMapper;
using TimeTracker.Application.Common.Mappings;
using TimeTracker.Application.Tags.Commands.UpdateTag;

namespace TimeTrackerApi.Models
{
    public class UpdateTagDto : IMapWith<UpdateTagCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTagDto, UpdateTagCommand>()
                .ForMember(cmd => cmd.Title,
                    opt => opt.MapFrom(dto => dto.Title))
                .ForMember(cmd => cmd.Id,
                    opt => opt.MapFrom(dto => dto.Id));
        }
    }
}
