using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TransporteBusesApp.Persistencia.AppRepositorios;
using TransporteBusesApp.Dominio;
namespace TransporteBusesApp.Frontend.Pages.Rutas
{
    public class Details : PageModel
    {
        [BindProperty]
        public Dominio.Rutas ruta { get; set; }
        private readonly IRepositorioRutas _reporutas;

        public Details(IRepositorioRutas reporutas)
        {
            _reporutas = reporutas;
        }
        public void OnGet(int id)
        {
            if(id > 0){
                ruta = _reporutas.GetStationsbyid(id);

            }
        }
    }
}