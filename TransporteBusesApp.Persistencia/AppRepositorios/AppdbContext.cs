using Microsoft.EntityFrameworkCore;
using System;
using TransporteBusesApp.Dominio;
 
namespace TransporteBusesApp.Persistencia
{
    public class AppdbContext: DbContext{
        public DbSet<Buses> Buses { get; set; }
        public DbSet<Estaciones> Estaciones { get; set; }
        public DbSet<Rutas> Rutas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=dbtransportes;"); //localdb
            optionsBuilder.UseSqlServer(@"Server=tcp:dbtransportesrv.database.windows.net,1433;Initial Catalog=dbtransportes;Persist Security Info=False;User ID=apptransportes;Password=Misiontic2022*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
       
    }
}
