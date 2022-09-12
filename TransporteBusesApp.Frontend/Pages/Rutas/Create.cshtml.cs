using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using TransporteBusesApp.Dominio;
using TransporteBusesApp.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TransporteBusesApp.Frontend.Pages

{
    public class FormRutasModel : PageModel
    {   
        [BindProperty]
        public Dominio.Rutas ruta { get; set; }
        List<Dominio.Estaciones> estaciones;
        [BindProperty]
        public List<SelectListItem> selectestaciones { get; set; }
        public IRepositorioRutas repositorioRutas { get; set; }
        public IRepositorioEstaciones repositorioEstaciones { get; set; }
        public FormRutasModel(IRepositorioRutas repositorioRutas,IRepositorioEstaciones repositorioEstaciones)
        {
            this.repositorioRutas = repositorioRutas;
            this.repositorioEstaciones = repositorioEstaciones;
        }
        public void OnGet()
        {

            estaciones = this.repositorioEstaciones.GetAll().ToList();
            selectestaciones = estaciones.Select(e => new SelectListItem
            {
                Value = e.id.ToString(),
                Text = e.nombre
            }).ToList();
        }
        
        

        public IActionResult OnPost(Dominio.Rutas ruta){
            this.repositorioRutas.Create(ruta);
            return RedirectToPage("./List");
        }
    }
}