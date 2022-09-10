using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransporteBusesApp.Dominio;

namespace TransporteBusesApp.Persistencia.AppRepositorios
{
    public class RepositorioRutas : IRepositorioRutas
    {
        List<Rutas> rutas;
        private IRepositorioEstaciones repositorioEstaciones = new RepositorioEstaciones();
        public RepositorioRutas()
        {
            Estaciones Estacion1 = repositorioEstaciones.GetWithId(1);
            Estaciones Estacion2 = repositorioEstaciones.GetWithId(2);
            Estaciones Estacion3 = repositorioEstaciones.GetWithId(3);
            rutas = new List<Rutas>
            {
                
                new Rutas{id=1, origen = repositorioEstaciones.GetWithId(1),destino = repositorioEstaciones.GetWithId(3), tiempo_estimado= 45},
                new Rutas{id=2, origen = Estacion3,destino = Estacion2, tiempo_estimado= 90},
                new Rutas{id=3, origen = Estacion2,destino = Estacion1, tiempo_estimado= 30},
                new Rutas{id=4, origen = Estacion3,destino = Estacion1, tiempo_estimado= 60}
            };
        }
        /// <summary>
        /// Este metodo almacena una Ruta en la base de datos
        /// </summary>
        /// <param name="ruta">recibe un obejto ruta con 2 objetos Estaciones </param>
        /// <returns>Retorna el ultimo valor almacenadoo</returns>
        public Rutas Create(Rutas ruta)
        {
            //se agrega la ruta
            rutas.Add(ruta);
            return rutas.Last();
        }

        public IEnumerable<Rutas> GetAll()
        {
            return rutas;
        }
        /// <summary>
        ///   se obtiene la ruta con el id  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna un objeto Ruta encontrado con el Id</returns>
        public Rutas GetWithId(int id)
        {
            return rutas.FirstOrDefault(ruta => ruta.id == id);
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