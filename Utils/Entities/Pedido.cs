using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Pedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PedidoId { get; set; }

        [Display(Name = "ProyectoId"), Required(ErrorMessage = "Campo requerido añoo!")]
        public int ProyectoId { get; set; }


        [Display(Name = "Codigo"), Required(ErrorMessage = "Campo requerido!")]
        public string Codigo { get; set; }


        [Display(Name = "FechaCreacion"), Required(ErrorMessage = "Campo requerido Categoria!")]
        public DateTime FechaCreacion { get; set; }


        [Display(Name = "Descripcion"), Required(ErrorMessage = "Campo requerido!")]
        public string Descripcion { get; set; }


        [Display(Name = "Observaciones"), Required(ErrorMessage = "Campo requerido!")]
        public string Observaciones { get; set; }


        [Display(Name = "Estado"), Required(ErrorMessage = "Campo requerido añoo!")]
        public int Estado { get; set; }

        
        [Display(Name = "FechaEntregado"), Required(ErrorMessage = "Campo requerido Categoria!")]
        public DateTime FechaEntregado { get; set; }


        [Display(Name = "Latitud"), Required(ErrorMessage = "Campo requerido añoo!")]
        public decimal Latitud { get; set; }


        [Display(Name = "Longitud"), Required(ErrorMessage = "Campo requerido añoo!")]
        public decimal Longitud { get; set; }


    }
}
