using MediatR;

namespace MeetupManager.Application.Meetups.Commands.DeleteMeetup
{
    public class DeleteMeetupCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
