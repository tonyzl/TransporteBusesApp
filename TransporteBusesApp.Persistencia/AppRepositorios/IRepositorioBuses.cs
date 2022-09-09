using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransporteBusesApp.Dominio;

namespace TransporteBusesApp.Persistencia.AppRepositorios
{
    public interface IRepositorioBuses
    {
        public IEnumerable<Buses> GetAll();
        public Buses GetWithId(int id);
        public Buses Update(Buses newbus);
        public Buses Create(Buses bus);
    }
}