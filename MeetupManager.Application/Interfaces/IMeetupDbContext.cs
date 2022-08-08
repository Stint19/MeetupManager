using MeetupManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace MeetupManager.Application.Interfaces
{
    public interface IMeetupDbContext
    {
        DbSet<Meetup> Meetups { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
