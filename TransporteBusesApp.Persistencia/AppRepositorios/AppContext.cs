using Microsoft.EntityFrameworkCore;
using TransporteBusesApp.Dominio;
 
namespace TransporteBusesApp.Persistencia
{
    public class AppContext: DbContext{
        public DbSet<Buses> Buses { get; set; }
        public DbSet<Estaciones> Estaciones { get; set; }
        public DbSet<Rutas> Rutas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = dbTransporteBuses");
            }
        }
    }
}
