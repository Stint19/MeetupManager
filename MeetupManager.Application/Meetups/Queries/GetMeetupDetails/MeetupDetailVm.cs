using AutoMapper;
using MeetupManager.Application.Common.Mappings;
using MeetupManager.Domain;

namespace MeetupManager.Application.Meetups.Queries.GetMeetupDetails
{
    public class MeetupDetailVm : IMapWith<Meetup>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public string Place { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Meetup, MeetupDetailVm>()
                .ForMember(meetupVm => meetupVm.Id,
                    opt => opt.MapFrom(meetup => meetup.Id))
                .ForMember(meetupVm => meetupVm.Title,
                    opt => opt.MapFrom(meetup => meetup.Title))
                .ForMember(meetupVm => meetupVm.Description,
                    opt => opt.MapFrom(meetup => meetup.Description))
                .ForMember(meetupVm => meetupVm.Organizer,
                    opt => opt.MapFrom(meetup => meetup.Organizer))
                .ForMember(meetupVm => meetupVm.StartDate,
                    opt => opt.MapFrom(meetup => meetup.StartDate))
                .ForMember(meetupVm => meetupVm.CreationDate,
                    opt => opt.MapFrom(meetup => meetup.CreationDate))
                .ForMember(meetupVm => meetupVm.EditDate,
                    opt => opt.MapFrom(meetup => meetup.EditDate))
                .ForMember(meetupVm => meetupVm.Place,
                    opt => opt.MapFrom(meetup => meetup.Place));
        }
    }
}
