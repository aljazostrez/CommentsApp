using CommentsApp.Core;
using Microsoft.EntityFrameworkCore;

namespace CommentsApp.EFCore
{
    public class CommentsAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        // this is just a demonstration of connecting to DB, so we use sqlite db as local file.
        // DB should be hosted somewhere and connection string should not be hardcoded, but configured
        // in appsettings.json or somewhere else (eg. MS Azure Key Vault)
        private string _dbPath { get; }

        public CommentsAppDbContext()
        {
            var startupPath = Directory.GetCurrentDirectory();
            _dbPath = Path.Join(startupPath, "commentsAppDb.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options.UseSqlite($"Data Source={_dbPath}");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasAlternateKey(x => x.Email);
        }
    }
}
