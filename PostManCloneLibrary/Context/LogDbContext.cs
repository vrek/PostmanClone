using Microsoft.EntityFrameworkCore;
using PostManCloneLibrary.Models;

namespace PostManCloneLibrary.Context
{
    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
        {
        }

        public DbSet<Response> LogEntries { get; set; } // Represents the Log table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define schema and constraints if needed
            modelBuilder.Entity<Response>()
                .Property(e => e.GUID)
                .IsRequired();
            modelBuilder.Entity<Response>()
                .Property(e => e.DateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }


}
