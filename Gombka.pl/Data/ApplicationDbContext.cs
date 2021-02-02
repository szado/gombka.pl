using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Gombka.pl.Models.Entities;

namespace Gombka.pl.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<VoteEntity>()
                .HasOne<VideoEntity>("Video")
                .WithMany("Votes")
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<VideoEntity> Videos { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<VoteEntity> Votes { get; set; }
    }
}
