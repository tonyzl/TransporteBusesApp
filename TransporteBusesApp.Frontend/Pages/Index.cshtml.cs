using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TransporteBusesApp.Persistencia.AppRepositorios;
using TransporteBusesApp.Dominio;

namespace TransporteBusesApp.Frontend.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Dominio.Rutas> rutasfiltradas { get; set; }
        private readonly IRepositorioRutas _reporutas;

        public IndexModel(IRepositorioRutas reporutas)
        {
            _reporutas = reporutas;
        }
        public void OnGet(List<Dominio.Rutas> rutasfiltradas)
        {
               if(rutasfiltradas != null)
            {

            } 
        }

        public IActionResult OnPostFilterList(int id_origen, int id_destino)
        {
            if (id_origen >0 && id_destino > 0) {
                
                return RedirectToPage("./Rutas/Estaciones/List",new{ idorigen = id_origen, iddestino = id_destino });
            }
            return Page();
        }
    }
}
