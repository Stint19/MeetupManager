namespace MeetupManager.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(MeetupDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
