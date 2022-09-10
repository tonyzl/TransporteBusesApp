using System;
using System.ComponentModel.DataAnnotations;
namespace TransporteBusesApp.Dominio{
    
    public class Buses
    {
        
        [Key, Required]
        [Display(Name="Id")]
        public int id {get;set;} 
        [Required]
        [Display(Name="Marca")]
        public string marca {get;set;}  

        [Required]
        [Display(Name="Modelo")]      
        public int modelo {get;set;}  

        [Required]
        [Display(Name="Kilometraje")]          
        public int kilometraje {get;set;}     

        [Required]
        [Display(Name="No. de Asientos")]       
        public int  nro_asientos{get;set;}   

        [Required]
        [Display(Name="Placa")]         
        public string placa {get;set;}            
           
    }
}