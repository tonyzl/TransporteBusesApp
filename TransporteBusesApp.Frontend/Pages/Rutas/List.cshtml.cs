using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TransporteBusesApp.Dominio;
using TransporteBusesApp.Persistencia.AppRepositorios;

namespace TransporteBusesApp.Frontend.Pages
{
    public class ListRutasModel : PageModel
    {
        private readonly IRepositorioRutas repositorioRutas;

        [BindProperty]
        public IEnumerable<Dominio.Rutas> Rutas { get; set; }

        public ListRutasModel(IRepositorioRutas repositorioRutas)
        {
            this.repositorioRutas = repositorioRutas;
        }
        public void OnGet()
        {
 
        }
    }
}