using AutoMapper;
using TimeTracker.Application.Common.Mappings;
using TimeTracker.Domain;

namespace TimeTracker.Application.Activities.Queries.GetActivityList
{
    public class ActivityLookupDto : IMapWith<Activity>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; }
        public Project? Project { get; set; }
        public int StartInMilliseconds { get; set; }
        public int? EndInMilliseconds { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Activity, ActivityLookupDto>()
                .ForMember(vm => vm.Id,
                    opt => opt.MapFrom(activity => activity.Id))
                .ForMember(vm => vm.Description,
                    opt => opt.MapFrom(activity => activity.Id))
                .ForMember(vm => vm.Tags,
                    opt => opt.MapFrom(activity => activity.Tags))
                .ForMember(vm => vm.Project,
                    opt => opt.MapFrom(activity => activity.Project))
                .ForMember(vm => vm.StartInMilliseconds,
                    opt => opt.MapFrom(activity => activity.StartInMilliseconds))
                .ForMember(vm => vm.EndInMilliseconds,
                    opt => opt.MapFrom(activity => activity.EndInMilliseconds));
        }
    }
}
