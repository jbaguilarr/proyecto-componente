using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCoreApp2.Models
{
    public class ProyectoViewModel
    {
        public Entities.Proyecto eProyecto { get; set; }
        public List<Entities.Proyecto> eListaProyecto { get; set; }

        public ProyectoViewModel() : base()
        {

        }

    }
}
