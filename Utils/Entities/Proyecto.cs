using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("tbl_Proyecto")]
   public  class Proyecto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProyectoId { get; set; }

        [Display(Name = "Nombre"), Required(ErrorMessage = "Campo requerido!")]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion"), Required(ErrorMessage = "Campo requerido Categoria!")]
        public string Descripcion { get; set; }

        [Display(Name = "UserId"), Required(ErrorMessage = "Campo requerido añoo!")]
        public int UserId { get; set; }
    }
}
