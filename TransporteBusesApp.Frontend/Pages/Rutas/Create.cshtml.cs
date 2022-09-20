using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using TransporteBusesApp.Dominio;
using TransporteBusesApp.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace TransporteBusesApp.Frontend.Pages

{
    [Authorize]
    public class FormRutasModel : PageModel
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
        public FormRutasModel(IRepositorioRutas repositorioRutas,IRepositorioEstaciones repositorioEstaciones)
        {
            _repositorioRutas = repositorioRutas;
            _repositorioEstaciones = repositorioEstaciones;
            
        }

        public void OnGet()
        {
            lst_origen = GetListEstaciones();
            lst_destino = GetListEstaciones();
            
        }
        
        

        public IActionResult OnPost(Dominio.Rutas ruta){
            
            if(ModelState.IsValid && ruta.origenid != ruta.destinoid){
            _repositorioRutas.Create(ruta);
            mensaje_guardado = "Ruta Creada Correctamente";
            return RedirectToPage("./List");
            }else{
                mensaje_error = "Error al crear la ruta valide que el origen y el destino no sean iguales";
                return RedirectToPage("./Create");
            }

            
        }

        //metodo para llenar las listas de estaciones
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