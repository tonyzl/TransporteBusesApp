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
    public class ListEstacionesModel : PageModel
    {
       
        private readonly IRepositorioEstaciones repositorioEstaciones;
        
        [BindProperty]
        public IEnumerable<Dominio.Estaciones> Estaciones {get;set;}
        [BindProperty]
        [TempData]
        public string mensaje_error { get; set; }
        [TempData]
        public string mensaje_guardado { get; set; }
        public Dominio.Estaciones Estacion {get;set;}
    
        public ListEstacionesModel(IRepositorioEstaciones repositorioEstaciones)
        {
            this.repositorioEstaciones=repositorioEstaciones;
        }
    
        public void OnGet()
        {
            Estaciones=repositorioEstaciones.GetAll();
        }
        public void OnPost()
        {

        }
        public IActionResult OnPostDelete(int id)
        {
            if(id > 0)
            {
                if(this.repositorioEstaciones.Delete(id)){
                    mensaje_guardado = "Estacion eliminada Correctamente";
                }else{
                    mensaje_error = "Error al momento de Eliminar la estacion valide que la estacion no tenga rutas relacionadas";
                }
                
                
            }

            return RedirectToPage("./List");
            
        }
    }
}