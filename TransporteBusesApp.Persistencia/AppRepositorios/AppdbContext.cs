using Microsoft.EntityFrameworkCore;
using TransporteBusesApp.Dominio;
 
namespace TransporteBusesApp.Persistencia
{
    public class AppdbContext: DbContext{
        public DbSet<Buses> Buses { get; set; }
        public DbSet<Estaciones> Estaciones { get; set; }
        public DbSet<Rutas> Rutas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=dbtransportes");
    }
       
    }
}
