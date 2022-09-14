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
        //optionsBuilder.UseSqlServer(@"Server=192.168.1.6\EDWINDB;Database=dbtransportes; user=EDWIN;password=edwin;");//Running on docker image
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=dbtransportes;");
    }
       
    }
}
