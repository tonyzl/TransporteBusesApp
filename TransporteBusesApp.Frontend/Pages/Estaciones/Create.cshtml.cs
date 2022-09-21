using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TransporteBusesApp.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Authorization;

namespace TransporteBusesApp.Frontend.Pages
{   [Authorize] 
    public class FormEstacionesModel : PageModel
    {
        private readonly IRepositorioEstaciones repositorioEstaciones;
        
        [BindProperty]
        public Dominio.Estaciones Estacion {get;set;}

        [TempData]
        public string mensaje_error { get; set; }
        [TempData]
        public string mensaje_guardado { get; set; }
        
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
                mensaje_guardado = "Estacion Creada Correctamente";
                return RedirectToPage("List");
            }else{
            mensaje_error = "Error al crear la Estacion";
            return RedirectToPage();
            }
        }
    }
}