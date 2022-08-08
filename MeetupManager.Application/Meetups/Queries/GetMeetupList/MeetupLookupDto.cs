using AutoMapper;
using MeetupManager.Application.Common.Mappings;
using MeetupManager.Domain;

namespace MeetupManager.Application.Meetups.Queries.GetMeetupList
{
    public class MeetupLookupDto : IMapWith<Meetup>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Meetup, MeetupLookupDto>()
                .ForMember(meetupDto => meetupDto.Id,
                    opt => opt.MapFrom(meetup => meetup.Id))
                .ForMember(meetupDto => meetupDto.Title,
                    opt => opt.MapFrom(meetup => meetup.Title));
        }
    }
}
