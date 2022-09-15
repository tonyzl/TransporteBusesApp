using System;
using System.Collections.Generic;
using TransporteBusesApp.Dominio;
using TransporteBusesApp.Persistencia;
using TransporteBusesApp.Persistencia.AppRepositorios;
namespace TransporteBusesApp.Consola
{
    class Program
    {
       
        
        static void Main(string[] args)
        {
            IRepositorioRutas _repo = new RepositorioRutas(new AppdbContext());
            var listrutas = (List<Rutas>)_repo.GetAll();
            foreach(var ruta in listrutas ){
                System.Console.WriteLine($"ruta: {ruta.id} origen: {ruta.origen.nombre} destino: {ruta.destino.nombre}"); 
                
            }
            System.Console.WriteLine("\n");
            
            
            var listrutas_f = _repo.GetbyStations(2,1);
            foreach(var ruta in listrutas_f ){
                System.Console.WriteLine($"ruta: {ruta.id} origen: {ruta.origen.nombre} destino: {ruta.destino.nombre}"); 
            }
        }
   
    }
}
    

