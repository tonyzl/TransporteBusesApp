using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace TransporteBusesApp.Frontend.Pages
{
    [Authorize]
    public class CasaEstacionesModel : PageModel
    {    
        public void OnGet()
        {
 
        }
    }    
}