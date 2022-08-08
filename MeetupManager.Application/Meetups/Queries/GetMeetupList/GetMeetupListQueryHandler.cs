using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MeetupManager.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeetupManager.Application.Meetups.Queries.GetMeetupList
{
    public class GetMeetupListQueryHandler : IRequestHandler<GetMeetupListQuery, MeetupListVm>
    {
        private readonly IMeetupDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMeetupListQueryHandler(IMeetupDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MeetupListVm> Handle(GetMeetupListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dbContext.Meetups
                .Where(meetup => meetup.UserId == request.UserId)
                .ProjectTo<MeetupLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MeetupListVm { Meetups = entities };
        }
    }
}
