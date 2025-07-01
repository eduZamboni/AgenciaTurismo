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
        public DbSet<Destino> Destinos { get; set; }
        public DbSet<PacoteTuristico> PacotesTuristicos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<PacoteTuristicoDestino> PacoteTuristicoDestinos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PacoteTuristicoDestino>()
                .HasKey(ptd => new { ptd.PacoteTuristicoId, ptd.DestinoId });

            modelBuilder.Entity<PacoteTuristicoDestino>()
                .HasOne(ptd => ptd.PacoteTuristico)
                .WithMany(pt => pt.PacoteTuristicoDestinos)
                .HasForeignKey(ptd => ptd.PacoteTuristicoId);

            modelBuilder.Entity<PacoteTuristicoDestino>()
                .HasOne(ptd => ptd.Destino)
                .WithMany(d => d.PacoteTuristicoDestinos)
                .HasForeignKey(ptd => ptd.DestinoId);
        }
    }
}
