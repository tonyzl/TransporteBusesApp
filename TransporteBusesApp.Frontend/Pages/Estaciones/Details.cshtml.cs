using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TransporteBusesApp.Persistencia.AppRepositorios;
using TransporteBusesApp.Dominio;
using Microsoft.AspNetCore.Authorization;
<<<<<<< HEAD

namespace TransporteBusesApp.Frontend.Pages
{
    [Authorize]
=======
 
namespace TransporteBusesApp.Frontend.Pages
{   [Authorize] 
>>>>>>> Paula
    public class DetailsEstacionModel : PageModel
    {
        #region constructor
        private readonly IRepositorioEstaciones repositorioEstaciones;
        public Dominio.Estaciones Estacion {get;set;}
        
        #endregion
        public DetailsEstacionModel(IRepositorioEstaciones repositorioEstaciones)
       {
            this.repositorioEstaciones=repositorioEstaciones;
       }
 
        public IActionResult OnGet(int estacionId)
        {
            Estacion=repositorioEstaciones.GetWithId(estacionId);
            return Page();
 
        }
    }
}