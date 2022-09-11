using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TransporteBusesApp.Persistencia.AppRepositorios;
using TransporteBusesApp.Dominio;
 
namespace TransporteBusesApp.Frontend.Pages
{
    public class ListEstacionesModel : PageModel
    {
       
        private readonly IRepositorioEstaciones repositorioEstaciones;
        
        [BindProperty]
        public IEnumerable<Dominio.Estaciones> Estaciones {get;set;}
        [BindProperty]
        public Dominio.Estaciones Estacion {get;set;}
    
        public ListEstacionesModel(IRepositorioEstaciones repositorioEstaciones)
        {
            this.repositorioEstaciones=repositorioEstaciones;
        }
    
        public void OnGet()
        {
            Estaciones=repositorioEstaciones.GetAll();
        }
        public void OnPost()
        {

        }
        public IActionResult OnPostDelete(int id)
        {
            if(Estacion.id > 0)
            {
                this.repositorioEstaciones.Delete(Estacion.id);
            }

            return RedirectToPage("./List");
        }
    }
}