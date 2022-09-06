using System.Collections.Generic;
using TransporteBusesApp.Dominio;
using System.Linq;
using System;
 
namespace TransporteBusesApp.Persistencia.AppRepositorios
{
    public class RepositorioBuses
    {
        List<Buses> buses;
 
    public RepositorioBuses()
        {
            buses= new List<Buses>()
            {
                new Buses{id=1,marca="Audi",modelo= 2020,kilometraje= 100000,nro_asientos= 4,placa= "POP678"},
                new Buses{id=2,marca="Toyota",modelo= 2021,kilometraje= 90000,nro_asientos= 16,placa= "OIU859"},
                new Buses{id=3,marca="Mazda",modelo= 2000,kilometraje= 150000,nro_asientos= 24,placa= "YUH859"}
 
            };
        }
 
        public IEnumerable<Buses> GetAll()
        {
            return buses;
        }
 
        public Buses GetWithId(int id){
            return buses.SingleOrDefault(b => b.id == id);
        }
    }
}