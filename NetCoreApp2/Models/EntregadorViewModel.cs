using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCoreApp2.Models
{
    public class EntregadorViewModel
    {
        public Entities.Entregador eEntregador { get; set; }
        public List<Entities.Entregador> eListaEntregador { get; set; }

        public EntregadorViewModel() : base()
        {

        }

    }
}
