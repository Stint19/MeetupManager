using FluentValidation;

namespace MeetupManager.Application.Meetups.Commands.UpdateMeetup
{
    public class UpdateMeetupCommandValidator : AbstractValidator<UpdateMeetupCommand>
    {
        public UpdateMeetupCommandValidator()
        {
            RuleFor(updateMeetupCommand =>
                updateMeetupCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(updateMeetupCommand =>
                updateMeetupCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateMeetupCommand =>
                updateMeetupCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
