using System.Collections.Generic;
using TransporteBusesApp.Dominio;
using System.Linq;
using System;
using System.IO;

namespace TransporteBusesApp.Persistencia.AppRepositorios
{
    public class RepositorioBuses : IRepositorioBuses
    {
        AppdbContext _appdbContext;
        public RepositorioBuses(AppdbContext appdbContext)
        {
            _appdbContext = appdbContext;
            
        }

        public Buses Create(Buses newBus) //se crea bus en la base de datos
        {
            var busagregado =_appdbContext.Buses.Add(newBus);
            _appdbContext.SaveChanges();
            return busagregado.Entity;
        }

        public bool Delete(int id) //se elimina un bus en la base de datos
        {
           Buses bus = _appdbContext.Buses.FirstOrDefault(b => b.id == id);

           if(bus != null){

            var buseliminado = _appdbContext.Buses.Remove(bus);
                _appdbContext.SaveChanges();
                if (buseliminado != null){
                    return true;
                }else{
                    return false;
                }

            }else{
                
                return false;
            }
        }

        public IEnumerable<Buses> GetAll() //se listan todos los buses en la base de datos
        {
            return _appdbContext.Buses.ToList();
        }
 
        public Buses GetWithId(int id){  //se busca un bus en la base de datos
            return _appdbContext.Buses.FirstOrDefault(b => b.id == id);
        }

        public Buses Update(Buses newBus){  //se edita un bus en la base de datos
            var bus= _appdbContext.Buses.FirstOrDefault(b => b.id == newBus.id);
            
            if(bus != null){
                
                bus.marca = newBus.marca;
                bus.modelo = newBus.modelo;
                bus.kilometraje = newBus.kilometraje;
                bus.nro_asientos = newBus.nro_asientos;
                bus.placa = newBus.placa;
                var busactualizado = _appdbContext.Buses.Update(bus);
                _appdbContext.SaveChanges();
            }
            return bus;
        } 


    }
}
