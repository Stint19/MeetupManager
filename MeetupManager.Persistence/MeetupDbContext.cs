using MeetupManager.Application.Interfaces;
using MeetupManager.Domain;
using MeetupManager.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace MeetupManager.Persistence
{
    public class MeetupDbContext : DbContext, IMeetupDbContext
    {
        public DbSet<Meetup> Meetups { get; set; }

        public MeetupDbContext(DbContextOptions<MeetupDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MeetupConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
