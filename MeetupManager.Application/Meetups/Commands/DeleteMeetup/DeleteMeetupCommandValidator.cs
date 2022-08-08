using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace MeetupManager.Application.Meetups.Commands.DeleteMeetup
{
    public class DeleteMeetupCommandValidator : AbstractValidator<DeleteMeetupCommand>
    {
        public DeleteMeetupCommandValidator()
        {
            RuleFor(deleteMeetupCommand =>
                deleteMeetupCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(deleteMeetupCommand =>
                deleteMeetupCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
