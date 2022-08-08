using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace MeetupManager.Application.Meetups.Commands.CreateMeetup
{
    public class CreateMeetupCommandValidator : AbstractValidator<CreateMeetupCommand>
    {
        public CreateMeetupCommandValidator()
        {
            RuleFor(createMeetupCommand =>
                createMeetupCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createMeetupCommand =>
                createMeetupCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
