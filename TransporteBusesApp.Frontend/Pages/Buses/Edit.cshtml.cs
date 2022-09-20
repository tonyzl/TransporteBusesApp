using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TransporteBusesApp.Persistencia.AppRepositorios;
using TransporteBusesApp.Dominio;
using Microsoft.AspNetCore.Authorization;

namespace TransporteBusesApp.Frontend.Pages
{
    [Authorize]
    public class EditBusModel : PageModel
    {
        private readonly IRepositorioBuses repositorioBuses;
        [BindProperty]
        public Dominio.Buses Bus {get;set;}
 
        [TempData]
        public string mensaje_error { get; set; }
        [TempData]
        public string mensaje_guardado { get; set; }
        public EditBusModel(IRepositorioBuses repositorioBuses)
        {
            this.repositorioBuses=repositorioBuses;
        }  

        public IActionResult OnGet(int busId)
        {
            Bus=repositorioBuses.GetWithId(busId);
            return Page();
        }
 
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                mensaje_error = "Error al Editar el bus";
                return Page();
            }
            if(Bus.id>0)
            {
             Bus = repositorioBuses.Update(Bus);
            }
            mensaje_guardado = "Bus Editado Correctamente";
            return RedirectToPage("List");
        }
    }
}
