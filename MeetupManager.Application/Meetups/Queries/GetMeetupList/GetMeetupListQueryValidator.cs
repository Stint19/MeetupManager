using FluentValidation;

namespace MeetupManager.Application.Meetups.Queries.GetMeetupList
{
    public class GetMeetupListQueryValidator : AbstractValidator<GetMeetupListQuery>
    {
        public GetMeetupListQueryValidator()
        {
            RuleFor(getMeetupDetailsQuery =>
                getMeetupDetailsQuery.UserId).NotEqual(Guid.Empty);
        }
    }
}
