using Microsoft.EntityFrameworkCore;

namespace AgenciaTurismo.Models
{
    public class AgenciaTurismoContext : DbContext
    {
        public AgenciaTurismoContext(DbContextOptions<AgenciaTurismoContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CidadeDestino> CidadesDestino { get; set; }
    }
}
