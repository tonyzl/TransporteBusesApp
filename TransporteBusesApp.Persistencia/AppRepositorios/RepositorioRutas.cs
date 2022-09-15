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

        /// <summary>
        /// Este metodo almacena una Ruta en la base de datos
        /// </summary>
        /// <param name="ruta">recibe un obejto ruta con 2 objetos Estaciones </param>
        /// <returns>Retorna el ultimo valor almacenadoo</returns>
        public Rutas Create(Rutas ruta) //se crea la ruta en la base de datos
        {

            var rutainsertada = _appContext.Rutas.Add(ruta);
            _appContext.SaveChanges();
            return rutainsertada.Entity;
            //se agrega la ruta


        }

        public bool Delete(int id) //se elimina una ruta en la base de datos
        {
            Rutas ruta = _appContext.Rutas.FirstOrDefault(r => r.id == id);

            if (ruta != null)
            {

                _appContext.Rutas.Remove(ruta);
                _appContext.SaveChanges();
                return true;
            }
            else
            {

                return false;
            }
        }

        public IEnumerable<Rutas> GetAll() // se listan todas las rutas en la base de datos
        {
            rutas = _appContext.Rutas
                .Include(u => u.origen)
                .Include(u => u.destino).ToList();

            return rutas;

        }
        /// <summary>
        ///   se obtiene la ruta con el id  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna un objeto Ruta encontrado con el Id</returns>
        public Rutas GetWithId(int id) //se busca una ruta en la base de datos
        {

            return _appContext.Rutas.FirstOrDefault(r => r.id == id);
        }

        public Rutas Update(Rutas newruta) //se actualiza una ruta en la base de datos
        {
            Rutas rutaencontrada = _appContext.Rutas.FirstOrDefault(r => r.id == newruta.id);
            if (rutaencontrada != null)
            {
                rutaencontrada.origenid = newruta.origenid;
                rutaencontrada.destinoid = newruta.destinoid;
                rutaencontrada.tiempo_estimado = newruta.tiempo_estimado;
                var actualizado = _appContext.Update(rutaencontrada);
                _appContext.SaveChanges();
                return actualizado.Entity;
            }

            return rutaencontrada;

        }

        public IEnumerable<Rutas> GetbyStations(int idorigen, int idDestino)
        {

            Estaciones Estacion1 = _repositorioEstaciones.GetWithId(1);
            Estaciones Estacion2 = _repositorioEstaciones.GetWithId(2);
            Estaciones Estacion3 = _repositorioEstaciones.GetWithId(3);
            List<Rutas> rutaslocal = new List<Rutas>
            {

                new Rutas{id=1, origen = _repositorioEstaciones.GetWithId(1),destino = _repositorioEstaciones.GetWithId(3), tiempo_estimado= 45},
                new Rutas{id=2, origen = Estacion3,destino = Estacion2, tiempo_estimado= 90},
                new Rutas{id=3, origen = Estacion2,destino = Estacion1, tiempo_estimado= 30},
                new Rutas{id=4, origen = Estacion3,destino = Estacion1, tiempo_estimado= 60},
                new Rutas{id=5, origen = Estacion3,destino = Estacion2, tiempo_estimado= 50},
                new Rutas{id=6, origen = Estacion3,destino = Estacion2, tiempo_estimado= 55},
            };
            var rutas_filtradas =
                 from ruta in rutaslocal
                 where ruta.origen.id == idorigen && ruta.destino.id == idDestino
                 select ruta;
            return rutas_filtradas;

        }
    }
}