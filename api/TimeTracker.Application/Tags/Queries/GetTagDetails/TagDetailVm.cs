using AutoMapper;
using TimeTracker.Application.Common.Mappings;
using TimeTracker.Domain;

namespace TimeTracker.Application.Tags.Queries.GetTagDetails
{
    public class TagDetailVm: IMapWith<Tag>
    { // TODO: add user id
        public Guid Id { get; set; }
        public string Title {  get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tag, TagDetailVm>()
                .ForMember(vm => vm.Id,
                    opt => opt.MapFrom(tag => tag.Id))
                .ForMember(vm => vm.Title,
                    opt => opt.MapFrom(tag => tag.Id))
                .ForMember(vm => vm.CreationDate,
                    opt => opt.MapFrom(tag => tag.CreationDate))
                .ForMember(vm => vm.EditDate,
                    opt => opt.MapFrom(tag => tag.EditDate));
        }
    }
}
