using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransporteBusesApp.Dominio;

namespace TransporteBusesApp.Persistencia.AppRepositorios
{
    public interface IRepositorioEstaciones
    {
         public IEnumerable<Dominio.Estaciones> GetAll();
        public Dominio.Estaciones GetWithId(int id);
        public Dominio.Estaciones Update(Dominio.Estaciones newbus);
        public Dominio.Estaciones Create(Dominio.Estaciones bus);
    }
}