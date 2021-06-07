using Microsoft.EntityFrameworkCore;
using OOP_Lab_5.Data.Entities;

namespace OOP_Lab_5.Data
{
    /// <summary>
    /// Provides access to database
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Set of MatrixEntity instances to be stored in database.
        /// </summary>
        public DbSet<MatrixEntity> Matrixes { get; set; }

        /// <summary>
        /// Constructs DatabaseContext instance.
        /// </summary>
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Configures database connection.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=OOP_Lab_5.db;Cache=Shared");
        }
    }
}
