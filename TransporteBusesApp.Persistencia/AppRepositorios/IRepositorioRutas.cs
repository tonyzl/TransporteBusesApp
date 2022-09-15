using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransporteBusesApp.Dominio;
namespace TransporteBusesApp.Persistencia.AppRepositorios
{
    
/// <summary>
/// se definen los metodos que debe implementar ReposiotorioRutas que son los metodos crud para Rutas
/// <code>
/// RepositorioRutas : IRepositorioRutas
/// </code>
/// </summary>
    public interface IRepositorioRutas
    {
        public IEnumerable<Rutas> GetAll();
        public Rutas GetWithId(int id);
        public Rutas Update(Rutas newbus);
        public Rutas Create(Rutas bus);
        public bool Delete(int id);
        public IEnumerable<Rutas> GetbyStations(int idorigen, int idDestino);
    }
    
}   