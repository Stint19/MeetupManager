using MediatR;
using MeetupManager.Application.Interfaces;
using MeetupManager.Domain;

namespace MeetupManager.Application.Meetups.Commands.CreateMeetup
{
    public class CreateMeetupCommandHandler
        : IRequestHandler<CreateMeetupCommand, Guid>
    {
        private readonly IMeetupDbContext _dbContext;

        public CreateMeetupCommandHandler(IMeetupDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateMeetupCommand request, CancellationToken cancellationToken)
        {
            var meetup = new Meetup
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description,
                Organizer = request.Organizer,
                Place = request.Place,
                StartDate = request.StartDate,
                CreationDate = DateTime.Now,
                EditDate = null
                
            };

            await _dbContext.Meetups.AddAsync(meetup, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return meetup.Id;
        }
    }
}
