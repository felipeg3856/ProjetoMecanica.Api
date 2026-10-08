using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using ProjetoMecanica.Api.Models;

namespace ProjetoMecanica.Api.Data
{
    public class AppDbContext : DbContext
    {
        internal object Clientes;

        public AppDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Usuario> Mecanico { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Agendamentos> Agendamentos { get; set; }
    }
}
