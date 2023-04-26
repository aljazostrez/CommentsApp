using CommentsApp.Core;
using Microsoft.EntityFrameworkCore;

namespace CommentsApp.EFCore
{
    public class CommentsAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        // the following constructor is used when configuring db on startup
        public CommentsAppDbContext(DbContextOptions<CommentsAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // we want emails to be unique
            modelBuilder.Entity<User>().HasAlternateKey(x => x.Email);
        }
    }
}
