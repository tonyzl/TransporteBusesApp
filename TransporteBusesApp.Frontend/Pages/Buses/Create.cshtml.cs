using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TransporteBusesApp.Dominio;
using TransporteBusesApp.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Authorization;

namespace TransporteBusesApp.Frontend.Pages
{   [Authorize] 
    public class FormBusesModel : PageModel
    {     
        
        private readonly IRepositorioBuses repositoriobuses; 
        
        [BindProperty]
        public Dominio.Buses bus {get; set;}
        
        [TempData]
        public string mensaje_error { get; set; }
        [TempData]
        public string mensaje_guardado { get; set; }

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
                mensaje_guardado = "Bus Creado Correctamente";
                return RedirectToPage("List");
            }
            mensaje_error = "Error al crear el bus";
            return Page();
        }
    }
}