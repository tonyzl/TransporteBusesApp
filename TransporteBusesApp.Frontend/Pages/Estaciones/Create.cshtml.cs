using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TransporteBusesApp.Persistencia.AppRepositorios;

namespace TransporteBusesApp.Frontend.Pages
{
    public class FormEstacionesModel : PageModel
    {
        private readonly IRepositorioEstaciones repositorioEstaciones;
        
        [BindProperty]
        public Dominio.Estaciones Estacion {get;set;}
        
        public FormEstacionesModel(IRepositorioEstaciones repositorioEstaciones)
        {
            this.repositorioEstaciones = repositorioEstaciones;
        }

        public void OnGet()
        {
 
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                repositorioEstaciones.Create(Estacion);
                return RedirectToPage("List");
            }

            return Page();
        }
    }
}