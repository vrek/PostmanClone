using Microsoft.EntityFrameworkCore;
using PostManCloneLibrary.Models;

namespace PostManCloneLibrary.Context
{
    public class LogDbContext(DbContextOptions<LogDbContext> options) : DbContext(options)
    {
        public DbSet<Response> LogEntries { get; set; } // Represents the Log table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define schema and constraints if needed
            _ = modelBuilder.Entity<Response>()
                .Property(e => e.GUID)
                .IsRequired();
            _ = modelBuilder.Entity<Response>()
                .Property(e => e.DateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }


}
