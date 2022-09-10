using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransporteBusesApp.Dominio{
    public class Rutas{
        [Required,Key]
        [Display(Name="Id")]
        public int id {get; set;}
        [Required, ForeignKey("Estaciones")]
        [Display(Name="Origen")]
        public virtual Estaciones origen {get; set;} 

        [Required, ForeignKey("Estaciones")]
        [Display(Name="Destino")]
        public virtual Estaciones destino {get; set;} 

        [Required]
        [Display(Name="Tiempo Estimado")]
        public int tiempo_estimado {get; set;} 
    }
}