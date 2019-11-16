using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregadorAPIController : ControllerBase
    {
        // GET: api/EntregadorAPI
        [HttpGet]
        public IEnumerable<Entities.Entregador> Get()
        {
            Business.Entregador oEntregador = new Business.Entregador();
            return oEntregador.GetListaEntregador();
        }

        // GET: api/EntregadorAPI/5
        [HttpGet("{id}", Name = "GetEntregador")]
        public Entities.Entregador Get(int id)
        {
            Business.Entregador oEntregador = new Business.Entregador();
            return oEntregador.GetEntregador(id);
        }

        // POST: api/EntregadorAPI
        [HttpPost]
        public void Post([FromBody] Entities.Entregador eEntregador)
        {
            Business.Entregador oEntregador = new Business.Entregador();
            oEntregador.Guardar(eEntregador);
        }

        // PUT: api/EntregadorAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Entities.Entregador eEntregador)
        {
            Business.Entregador oEntregador = new Business.Entregador();
            oEntregador.Modificar(eEntregador);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Business.Entregador oEntregador = new Business.Entregador();
            oEntregador.Eliminar(id);
        }
    }
}
