using MediatR;

namespace MeetupManager.Application.Meetups.Commands.CreateMeetup
{
    public class CreateMeetupCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public DateTime StartDate { get; set; }
        public string Place { get; set; }
    }
}
