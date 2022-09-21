using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TransporteBusesApp.Dominio;
using TransporteBusesApp.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace TransporteBusesApp.Frontend.Pages.Rutas
{   [Authorize] 
    public class Edit : PageModel
    {
        [BindProperty]
        public Dominio.Rutas ruta { get; set; }

        [BindProperty]
        public List<SelectListItem> lst_origen { get; set; }
        [BindProperty]
        public List<SelectListItem> lst_destino { get; set; }
        [TempData]
        public string mensaje_error { get; set; }
        [TempData]
        public string mensaje_guardado { get; set; }
        public IRepositorioRutas _repositorioRutas { get; set; }
        public IRepositorioEstaciones _repositorioEstaciones { get; set; }
        public Edit(IRepositorioRutas repositorioRutas,IRepositorioEstaciones repositorioEstaciones)
        {
            _repositorioRutas = repositorioRutas;
            _repositorioEstaciones = repositorioEstaciones;
            
        }

        public void OnGet(int id)
        {
            lst_origen = GetListEstaciones();
            lst_destino = GetListEstaciones();

               if(id > 0){
                ruta = _repositorioRutas.GetWithId(id);

            }
            
            
        }
         public IActionResult OnPost(Dominio.Rutas ruta){
            
            if(ModelState.IsValid && ruta.origenid != ruta.destinoid){
            _repositorioRutas.Update(ruta);
            mensaje_guardado = "Ruta actualizada Correctamente";
            return RedirectToPage("./List");
            }else{
                mensaje_error = "Error al actualizar la ruta valide que el origen y el destino no sean iguales";
                //return Page(); //metodo para que el sistema mantenga el id  es decir la misma vista
            return RedirectToPage("./List");
            }
         }
        //metodo para llenar las listas de estaciones en la lista de rutas 
        public List<SelectListItem> GetListEstaciones(){
            var selectestaciones = new List<SelectListItem>();
            List<Dominio.Estaciones> estaciones = _repositorioEstaciones.GetAll().ToList();
            
            selectestaciones = estaciones.Select(e => new SelectListItem
            {
                Value = e.id.ToString(),
                Text = e.nombre
            }).ToList();

            return selectestaciones;
        }

    }
}