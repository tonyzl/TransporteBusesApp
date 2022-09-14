using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransporteBusesApp.Dominio;
using Microsoft.EntityFrameworkCore;

namespace TransporteBusesApp.Persistencia.AppRepositorios
{
    public class RepositorioRutas : IRepositorioRutas
    {
        List<Rutas> rutas;
        private IRepositorioEstaciones _repositorioEstaciones;

        private readonly AppdbContext _appContext;
        public RepositorioRutas(AppdbContext appContext)
        {
            _appContext = appContext;
            _repositorioEstaciones = new RepositorioEstaciones(appContext);
        }
        public RepositorioRutas()
        {
            /*
            Estaciones Estacion1 = _repositorioEstaciones.GetWithId(1);
            Estaciones Estacion2 = _repositorioEstaciones.GetWithId(2);
            Estaciones Estacion3 = _repositorioEstaciones.GetWithId(3);
            rutas = new List<Rutas>
            {
                
                new Rutas{id=1, origen = _repositorioEstaciones.GetWithId(1),destino = _repositorioEstaciones.GetWithId(3), tiempo_estimado= 45},
                new Rutas{id=2, origen = Estacion3,destino = Estacion2, tiempo_estimado= 90},
                new Rutas{id=3, origen = Estacion2,destino = Estacion1, tiempo_estimado= 30},
                new Rutas{id=4, origen = Estacion3,destino = Estacion1, tiempo_estimado= 60}
            };*/
        }
        /// <summary>
        /// Este metodo almacena una Ruta en la base de datos
        /// </summary>
        /// <param name="ruta">recibe un obejto ruta con 2 objetos Estaciones </param>
        /// <returns>Retorna el ultimo valor almacenadoo</returns>
        public Rutas Create(Rutas ruta)
        {
            Estaciones origen = _repositorioEstaciones.GetWithId(ruta.origen.id);
            Estaciones destino = _repositorioEstaciones.GetWithId(ruta.destino.id);
            ruta.origen = origen;
            ruta.destino = destino;
            

            var rutainsertada = _appContext.Rutas.Add(ruta);
            return rutainsertada.Entity;
            //se agrega la ruta


        }

        public bool Delete(int id)
        {
            Rutas ruta = rutas.FirstOrDefault(r => r.id == id);

           if(ruta != null){

            return rutas.Remove(ruta);

            }else{
                
                return false;
            }
        }

        public IEnumerable<Rutas> GetAll()
        {
           return _appContext.Rutas
                .Include(u => u.origen)
                .Include(u => u.destino);

        }
        /// <summary>
        ///   se obtiene la ruta con el id  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna un objeto Ruta encontrado con el Id</returns>
        public Rutas GetWithId(int id)
        {
             return _appContext.Rutas.Find(id);
        }

        public Rutas Update(Rutas newruta)
        {
           Rutas rutaencontrada = rutas.FirstOrDefault(r => r.id == newruta.id);
           if(rutaencontrada != null)
           {
                rutaencontrada.origen = newruta.origen;
                rutaencontrada.destino = newruta.destino;
                rutaencontrada.tiempo_estimado = newruta.tiempo_estimado;
                
                return rutaencontrada;
            }

            return rutaencontrada;

        }
    }
}