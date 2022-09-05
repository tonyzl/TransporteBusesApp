using System.Collections.Generic;
using TransporteBusesApp.Dominio;
using System.Linq;
using System;
 
namespace TransporteBusesApp.Persistencia.AppRepositorios
{
    public class RepositorioEstaciones
    {
        List<Estaciones> estaciones;
 
    public RepositorioEstaciones()
        {
            estaciones= new List<Estaciones>()
            {
                new Estaciones{id=1,nombre="Centro",direccion= "cra 90",coord_x= "14.4545",coord_y= "4.1254545",tipo= "Principal"},
                new Estaciones{id=2,nombre="Estadio",direccion= "calle 70",coord_x= "9.05454",coord_y= "16.14587",tipo= "Segundaria"},
                new Estaciones{id=3,nombre="Terminal",direccion= "Carrera 54",coord_x= "15.457878",coord_y= "24.457878",tipo= "Principal"}
            };
        }
 
        public IEnumerable<Estaciones> GetAll()
        {
            return estaciones;
        }
 
        public Estaciones GetWithId(int id){
            return estaciones.SingleOrDefault(e => e.id == id);
        }
    }
}