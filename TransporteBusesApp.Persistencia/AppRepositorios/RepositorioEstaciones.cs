using System.Collections.Generic;
using TransporteBusesApp.Dominio;
using System.Linq;
using System;
 
namespace TransporteBusesApp.Persistencia.AppRepositorios
{
    public class RepositorioEstaciones :IRepositorioEstaciones
    {
        private readonly AppdbContext _appContext;
        public RepositorioEstaciones(AppdbContext appcontext)
        {
            _appContext = appcontext;
        }
        public IEnumerable<Estaciones> GetAll() //se listan  las estaciones en la base de datos
        {
            return _appContext.Estaciones;
        }
 
        public Estaciones GetWithId(int id){ //se busca una estacion en la base de datos con id
            return _appContext.Estaciones.Find(id);
        }

        public Estaciones Create(Estaciones newEstacion) //se crea una estacion en la base de datos
        {
            var addEstacion= _appContext.Estaciones.Add(newEstacion);
            _appContext.SaveChanges();
            return addEstacion.Entity;
        }

        public Estaciones Update(Estaciones newEstacion) // se actualiza una estacion en la base de datos
        {
            var estacion = _appContext.Estaciones.Find(newEstacion.id);

            if(estacion != null){
                estacion.nombre = newEstacion.nombre;
                estacion.direccion = newEstacion.direccion;
                estacion.coord_x = newEstacion.coord_x;
                estacion.coord_y = newEstacion.coord_y;
                estacion.tipo = newEstacion.tipo;
                //Guardar en base de datos
                 _appContext.SaveChanges();
            }
            
            return estacion;
        } 

        public bool Delete(int id) //se elimina una estacion en la base de datos
        {
           
            var estacion = _appContext.Estaciones.FirstOrDefault(e => e.id == id);
            
           if(estacion != null){
            try
            {
                
                _appContext.Estaciones.Remove(estacion);
                _appContext.SaveChanges();
                    return true;
                }
            catch (System.Exception)
            {
                
                return false;
            }

            
            }else{
                return false;
            }
            
            

            
                
            }
        }  
    }
