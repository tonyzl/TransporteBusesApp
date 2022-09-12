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
    public class ListBusModel : PageModel
    {
       
        private readonly IRepositorioBuses repositorioBuses;
        [BindProperty]
        
        public IEnumerable<Dominio.Buses> Buses {get;set;}

        [BindProperty]
        public Dominio.Buses bus { get; set; }
    public ListBusModel(IRepositorioBuses repositorioBuses)
    {
        this.repositorioBuses=repositorioBuses;
     }
 
    public void OnGet()
    {
        Buses=repositorioBuses.GetAll();
    }
    public IActionResult OnPostDelete(int id)
        {


            this.repositorioBuses.Delete(bus.id);
            return RedirectToPage("./List");
        }

            
    }
}
