using Microsoft.EntityFrameworkCore;

namespace MarsRobot.Api.Models
{
    public class RobotContext: DbContext
    {
        public RobotContext(DbContextOptions<RobotContext> options): base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Robot>()
                .HasKey(c => c.Id);
            modelBuilder.Seed();
        }
        public DbSet<Robot> Robots { get; set;}

    }
}
