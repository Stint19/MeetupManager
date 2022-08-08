using AutoMapper;
using MediatR;
using MeetupManager.Application.Common.Exceptions;
using MeetupManager.Application.Interfaces;
using MeetupManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace MeetupManager.Application.Meetups.Queries.GetMeetupDetails
{
    public class GetMeetupDetailsHandler
        : IRequestHandler<GetMeetupDetailsQuery, MeetupDetailVm>
    {
        private readonly IMeetupDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMeetupDetailsHandler(IMeetupDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<MeetupDetailVm> Handle(GetMeetupDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meetups
                .FirstOrDefaultAsync(meetup =>
                    meetup.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Meetup), request.Id);
            }

            return _mapper.Map<MeetupDetailVm>(entity);
        }
    }
}
