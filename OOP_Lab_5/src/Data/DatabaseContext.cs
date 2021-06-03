using Microsoft.EntityFrameworkCore;
using OOP_Lab_5.Data.Entities;

namespace OOP_Lab_5.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<MatrixEntity> Matrixes { get; set; }

        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=OOP_Lab_5.db;Cache=Shared");
        }
    }
}
