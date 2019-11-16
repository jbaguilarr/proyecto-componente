using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("tbl_Entregador")]
    public class Entregador
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EntregadorId { get; set; }

        [Display(Name = "Codigo"), Required(ErrorMessage = "Campo requerido!")]
        public int Codigo { get; set; }

        [Display(Name = "Nombre"), Required(ErrorMessage = "Campo requerido Categoria!")]
        public string Nombre { get; set; }
                
        [Display(Name = "Telefono"), Required(ErrorMessage = "Campo requerido Categoria!")]
        public string Telefono { get; set; }


        [Display(Name = "ProyectoId"), Required(ErrorMessage = "Campo requerido añoo!")]
        public int ProyectoId { get; set; }

    }
}
