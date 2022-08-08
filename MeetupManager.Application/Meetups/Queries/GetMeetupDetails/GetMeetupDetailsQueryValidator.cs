using FluentValidation;

namespace MeetupManager.Application.Meetups.Queries.GetMeetupDetails
{
    public class GetMeetupDetailsQueryValidator : AbstractValidator<GetMeetupDetailsQuery>
    {
        public GetMeetupDetailsQueryValidator()
        {
            RuleFor(getMeetupDetailsQuery =>
                getMeetupDetailsQuery.UserId).NotEqual(Guid.Empty);
            RuleFor(getMeetupDetailsQuery =>
                getMeetupDetailsQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
