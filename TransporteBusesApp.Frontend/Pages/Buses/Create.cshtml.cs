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
    
    public class FormBusesModel : PageModel
    {
       
        private readonly IRepositorioBuses repositoriobuses; 
        
        [BindProperty]
        public Dominio.Buses bus {get; set;}

         public FormBusesModel(IRepositorioBuses repositoriobuses)
        {
            this.repositoriobuses = repositoriobuses;
        }
        public void OnGet()
        {
 
        }
        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                repositoriobuses.Create(bus);
                return RedirectToPage("List");
            }

            return Page();
        }
    }
}