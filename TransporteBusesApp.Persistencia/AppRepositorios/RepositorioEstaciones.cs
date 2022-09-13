using System.Collections.Generic;
using TransporteBusesApp.Dominio;
using System.Linq;
using System;
 
namespace TransporteBusesApp.Persistencia.AppRepositorios
{
    public class RepositorioEstaciones :IRepositorioEstaciones
    {
        private readonly AppContext _appContext = new AppContext();         

        public IEnumerable<Estaciones> GetAll()
        {
            return _appContext.Estaciones;
        }
 
        public Estaciones GetWithId(int id){
            return _appContext.Estaciones.Find(id);
        }

        public Estaciones Create(Estaciones newEstacion)
        {
            var addEstacion= _appContext.Estaciones.Add(newEstacion);
            _appContext.SaveChanges();
            return addEstacion.Entity;
        }

        public Estaciones Update(Estaciones newEstacion)
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

        public bool Delete(int id)
        {
            var estacion = _appContext.Estaciones.Find(id);
            if (estacion == null)
                return false;
                
            _appContext.Estaciones.Remove(estacion);
            _appContext.SaveChanges();

            return true;
        }  
    }
}