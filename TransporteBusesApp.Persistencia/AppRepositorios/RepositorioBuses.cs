using System.Collections.Generic;
using TransporteBusesApp.Dominio;
using System.Linq;
using System;
 
namespace TransporteBusesApp.Persistencia.AppRepositorios
{
    public class RepositorioBuses : IRepositorioBuses
    {
        List<Buses> buses;
        AppTransportesdbContext _db;
        public RepositorioBuses(AppTransportesdbContext db)
        {
            _db = db;
            
        }

        public Buses Create(Buses newBus)
        {
            if(buses.Count > 0){
                newBus.id = buses.Max(r => r.id) +1; 
            } else {
               newBus.id = 1; 
            }

            buses.Add(newBus);
            return newBus;
        }

        public bool Delete(int id)
        {
           Buses bus = buses.FirstOrDefault(b => b.id == id);

           if(bus != null){

            return buses.Remove(bus);

            }else{
                
                return false;
            }
        }

        public IEnumerable<Buses> GetAll()
        {
            return _db.Buses.ToList();
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
