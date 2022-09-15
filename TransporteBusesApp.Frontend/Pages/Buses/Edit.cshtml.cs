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
                TempData["error"] = "Error al Editar el bus";
                return Page();
            }
            if(Bus.id>0)
            {
             Bus = repositorioBuses.Update(Bus);
            }
            TempData["success"] = "Bus Editado Correctamente";
            return RedirectToPage("List");
        }
    }
}
