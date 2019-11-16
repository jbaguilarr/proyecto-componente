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
    public class ProyectoAPIController : ControllerBase
    {

        // GET: api/ProyectoAPI
        [HttpGet]
        public IEnumerable<Entities.Proyecto> Get()
        {
            Business.Proyecto oProyecto = new Business.Proyecto();
            return oProyecto.GetListaProyecto();
        }

        // GET: api/ProyectoAPI/5
        [HttpGet("{id}", Name = "GetProyecto")]
        public Entities.Proyecto Get(int id)
        {
            Business.Proyecto oProyecto = new Business.Proyecto();
            return oProyecto.GetProyecto(id);
        }

        // POST: api/ProyectoAPI
        [HttpPost]
        public void Post([FromBody] Entities.Proyecto eProyecto)
        {
            Business.Proyecto oProyecto = new Business.Proyecto();
            oProyecto.Guardar(eProyecto);
        }

        // PUT: api/ProyectoAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Entities.Proyecto eProyecto)
        {
            Business.Proyecto oProyecto = new Business.Proyecto();
            oProyecto.Modificar(eProyecto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Business.Proyecto oProyecto = new Business.Proyecto();
            oProyecto.Eliminar(id);
        }

    }


}