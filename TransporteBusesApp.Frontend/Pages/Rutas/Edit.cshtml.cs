using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TransporteBusesApp.Frontend.Pages.Rutas
{
    public class Edit : PageModel
    {
        //TempData["success"] = "Ruta Editada Correctamente";
        //TempData["error"] = "Error al Editar la ruta valide que el origen y el destino no sean iguales";
        private readonly ILogger<Edit> _logger;

        public Edit(ILogger<Edit> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}