using AutoMapper;
using MeetupManager.Application.Common.Mappings;
using MeetupManager.Application.Meetups.Commands.CreateMeetup;
using MeetupManager.Application.Meetups.Commands.UpdateMeetup;

namespace MeetupManager.WebApi.Models
{
    public class UpdateMeetupDto : IMapWith<UpdateMeetupCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public DateTime StartDate { get; set; }
        public string Place { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMeetupDto, UpdateMeetupCommand>()
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
                .ForMember(meetupVm => meetupVm.Place,
                    opt => opt.MapFrom(meetup => meetup.Place));
        }
    }
}
