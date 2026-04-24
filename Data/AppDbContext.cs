using Microsoft.EntityFrameworkCore;
using APIhibridaASP.Models;

namespace APIhibridaASP.Data
{
    public class AppDbContext : DbContext
    {
     
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Material> Material { get; set; }
    }
}
