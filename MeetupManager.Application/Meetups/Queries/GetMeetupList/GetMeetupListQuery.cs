using MediatR;

namespace MeetupManager.Application.Meetups.Queries.GetMeetupList
{
    public class GetMeetupListQuery : IRequest<MeetupListVm>
    {
        public Guid UserId { get; set; }
    }
}
