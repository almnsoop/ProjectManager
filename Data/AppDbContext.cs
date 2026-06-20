using Microsoft.EntityFrameworkCore;
using ProjectManager.Models;

namespace ProjectManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // هنا نخبر البرنامج بأن يحول هذه الكلاسات إلى جداول حقيقية
        public DbSet<Client> Clients { get; set; }
        public DbSet<Website> Websites { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}