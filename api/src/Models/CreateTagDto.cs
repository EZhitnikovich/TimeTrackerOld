using AutoMapper;
using TimeTracker.Application.Common.Mappings;
using TimeTracker.Application.Tags.Commands.CreateTag;

namespace TimeTrackerApi.Models
{
    public class CreateTagDto : IMapWith<CreateTagCommand>
    {
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTagDto, CreateTagCommand>()
                .ForMember(cmd => cmd.Title,
                    opt => opt.MapFrom(dto => dto.Title));
        }
    }
}
