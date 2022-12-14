using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TransporteBusesApp.Dominio;
using TransporteBusesApp.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Authorization;

namespace TransporteBusesApp.Frontend.Pages
{
    [Authorize]
    public class ListRutasModel : PageModel
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

        public ListRutasModel(IRepositorioRutas repositorioRutas)
        {
            this.repositorioRutas = repositorioRutas;
        }
        public void OnGet()
        {
            rutas = repositorioRutas.GetAll();
        }

        public IActionResult OnPostDelete(int id)
        {
            this.repositorioRutas.Delete(ruta.id);
            return RedirectToPage("./List");
        }
        
            
        }

    }
