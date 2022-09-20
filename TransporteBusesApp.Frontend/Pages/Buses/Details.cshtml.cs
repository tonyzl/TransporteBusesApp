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
    public class DetailsBusModel : PageModel
    {
       private readonly IRepositorioBuses repositorioBuses;
              public Dominio.Buses Bus {get;set;}
 
        public DetailsBusModel(IRepositorioBuses repositorioBuses)
       {
            this.repositorioBuses=repositorioBuses;
       }
 
        public IActionResult OnGet(int busId)
        {
                Bus=repositorioBuses.GetWithId(busId);
                return Page();
 
        }
    }
}
