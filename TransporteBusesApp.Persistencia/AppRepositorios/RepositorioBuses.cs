using System.Collections.Generic;
using TransporteBusesApp.Dominio;
using System.Linq;
using System;
 
namespace TransporteBusesApp.Persistencia.AppRepositorios
{
    public class RepositorioBuses : IRepositorioBuses
    {
        List<Buses> buses;
 
    public RepositorioBuses()
        {
            buses= new List<Buses>()
            {
                new Buses{id=1,marca="Audi",foto= "audiPOP678.jpg",modelo= 2020,kilometraje= 100000,nro_asientos= 4,placa= "POP678"},
                new Buses{id=2,marca="Toyota",foto= "mazdaYUH859.png",modelo= 2021,kilometraje= 90000,nro_asientos= 16,placa= "OIU859"},
                new Buses{id=3,marca="Mazda",foto= "toyotaOIU859.jpeg",modelo= 2000,kilometraje= 150000,nro_asientos= 24,placa= "YUH859"}
 
            };
        }

        public Buses Create(Buses bus)
        {
            buses.Add(bus);
            return buses.Last();
        }

        public IEnumerable<Buses> GetAll()
        {
            
            return buses;
        }
 
        public Buses GetWithId(int id){
            return buses.SingleOrDefault(b => b.id == id);
        }

        public Buses Update(Buses newBus){
            var bus= buses.SingleOrDefault(b => b.id == newBus.id);
            if(bus != null){
                
                bus.marca = newBus.marca;
                bus.modelo = newBus.modelo;
                bus.kilometraje = newBus.kilometraje;
                bus.nro_asientos = newBus.nro_asientos;
                bus.placa = newBus.placa;
            }
        return bus;
        }

        
    }
}
