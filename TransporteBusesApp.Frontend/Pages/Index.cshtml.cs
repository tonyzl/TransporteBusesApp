using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TransporteBusesApp.Persistencia.AppRepositorios;
using TransporteBusesApp.Dominio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TransporteBusesApp.Frontend.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Dominio.Rutas ruta { get; set; }

        [BindProperty]
        public int id_origen { get; set; }
        [BindProperty]
        public int id_destino { get; set; }
        public List<SelectListItem> lst_origen { get; set; }

        [BindProperty]
        public List<SelectListItem> lst_destino { get; set; }

        private readonly IRepositorioRutas _reporutas;
        public IRepositorioEstaciones _repoestaciones { get; set; }
        public IndexModel(IRepositorioRutas reporutas, IRepositorioEstaciones repoestaciones)

        {
            _reporutas = reporutas;
            _repoestaciones = repoestaciones;
        }
        public void OnGet()
        {
            lst_origen = GetListEstaciones();
            lst_destino = GetListEstaciones();
        }

        public IActionResult OnPost()
        {
           
            if (id_origen >0 && id_destino > 0) {
                
                return RedirectToPage("./Rutas/Estaciones/List",new{ idorigen = id_origen, iddestino = id_destino });
            }
            return RedirectToPage("Index");
        }

        public List<SelectListItem> GetListEstaciones()
        {
            var selectestaciones = new List<SelectListItem>();
            List<Dominio.Estaciones> estaciones = _repoestaciones.GetAll().ToList();

            selectestaciones = estaciones.Select(e => new SelectListItem
            {
                Value = e.id.ToString(),
                Text = e.nombre
            }).ToList();

            return selectestaciones;
        }
    }
}
