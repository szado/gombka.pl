using Microsoft.EntityFrameworkCore;
using Gombka.pl.Models.Entities;

namespace Gombka.pl.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
    }
}