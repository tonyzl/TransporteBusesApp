using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TransporteBusesApp.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Authorization;

namespace TransporteBusesApp.Frontend.Pages.Rutas.Estaciones
{
    [Authorize]
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
        public void OnGet(int idorigen, int iddestino)
        {
            rutas = repositorioRutas.GetbyStations(idorigen, iddestino);
            
        }

        
            
        }

    }
    
