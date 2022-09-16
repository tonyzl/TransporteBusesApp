using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TransporteBusesApp.Persistencia.AppRepositorios;

namespace TransporteBusesApp.Frontend.Pages.Rutas.Estaciones
{
    public class List : PageModel
    {
      
        private readonly IRepositorioRutas repositorioRutas;

        [BindProperty]
        public IEnumerable<Dominio.Rutas> rutas { get; set; }

        [BindProperty]
        public Dominio.Rutas ruta { get; set; }
        [TempData]
        public string mensaje_error { get; set; }
        [TempData]
        public string mensaje_guardado { get; set; }

        public List(IRepositorioRutas repositorioRutas)
        {
            this.repositorioRutas = repositorioRutas;
        }
        public IActionResult OnGet(int idorigen,int iddestino)
        {
            rutas = repositorioRutas.GetbyStations(idorigen, iddestino);
            return RedirectToPage("./list");
        }

        
            
        }

    }
    
