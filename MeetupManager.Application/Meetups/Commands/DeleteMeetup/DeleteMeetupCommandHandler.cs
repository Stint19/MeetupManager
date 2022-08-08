using MediatR;
using MeetupManager.Application.Common.Exceptions;
using MeetupManager.Application.Interfaces;
using MeetupManager.Domain;

namespace MeetupManager.Application.Meetups.Commands.DeleteMeetup
{
    public class DeleteMeetupCommandHandler
        : IRequestHandler<DeleteMeetupCommand>
    {
        public readonly IMeetupDbContext _dbContext;

        public DeleteMeetupCommandHandler(IMeetupDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteMeetupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meetups
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
                throw new NotFoundException(nameof(Meetup), request.Id);

            _dbContext.Meetups.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
