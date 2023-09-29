using AutoMapper;
using TimeTracker.Application.Common.Mappings;
using TimeTracker.Domain;

namespace TimeTracker.Application.Tags.Queries.GetTagList
{
    public class TagLookupDto : IMapWith<Tag>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tag, TagLookupDto>()
                .ForMember(vm => vm.Id,
                    opt => opt.MapFrom(tag => tag.Id))
                .ForMember(vm => vm.Title,
                    opt => opt.MapFrom(tag => tag.Id));
        }
    }
}
