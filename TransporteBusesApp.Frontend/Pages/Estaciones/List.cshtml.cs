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
    public class ListEstacionesModel : PageModel
    {
       
    private readonly RepositorioEstaciones repositorioEstaciones;
    public IEnumerable<Estaciones> Estaciones {get;set;}
 
    public ListEstacionesModel(RepositorioEstaciones repositorioEstaciones)
    {
        this.repositorioEstaciones=repositorioEstaciones;
    }
 
    public void OnGet()
    {
        Estaciones=repositorioEstaciones.GetAll();
    }
    }
}