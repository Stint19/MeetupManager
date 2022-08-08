using MediatR;
using MeetupManager.Application.Common.Exceptions;
using MeetupManager.Application.Interfaces;
using MeetupManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace MeetupManager.Application.Meetups.Commands.UpdateMeetup
{
    public class UpdateMeetupCommandHandler
        : IRequestHandler<UpdateMeetupCommand>
    {
        private readonly IMeetupDbContext _dbContext;
        public UpdateMeetupCommandHandler(IMeetupDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateMeetupCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Meetups.FirstOrDefaultAsync(meetup =>
                    meetup.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Meetup), request.Id);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Organizer = request.Organizer;
            entity.Place = request.Place;
            entity.EditDate = DateTime.Now;
            entity.StartDate = request.StartDate;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
