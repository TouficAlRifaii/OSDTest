using Microsoft.EntityFrameworkCore;
using Backend.Models;
namespace Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos  { get; set; }
        public DbSet<Importance> Importances { get; set; }

        
    }
}
