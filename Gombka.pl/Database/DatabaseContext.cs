using Microsoft.EntityFrameworkCore;
using Gombka.pl.Models.Entities;

namespace Gombka.pl.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VoteEntity>()
                .HasOne<VideoEntity>("Video")
                .WithMany("Votes")
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<VideoEntity> Videos { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<VoteEntity> Votes { get; set; }
    }
}