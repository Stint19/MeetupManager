using MediatR;

namespace MeetupManager.Application.Meetups.Queries.GetMeetupDetails
{
    public class GetMeetupDetailsQuery : IRequest<MeetupDetailVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
