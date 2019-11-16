using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreApp2.Models;
//using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


using Utils;

namespace NetCoreApp2.Controllers
{
    public class ProyectoController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Listado()
        {
            ProyectoViewModel vProyectoViewModel = new ProyectoViewModel();
            /* ------------------------------Cargada items para el menu ------------------- */
            vProyectoViewModel.eListaProyecto = new Business.Proyecto().GetListaProyecto().ToList();

            return View(vProyectoViewModel);
        }


        [HttpGet]
        public List<Entities.Proyecto> Listado2()
        {
            ProyectoViewModel vProyectoViewModel = new ProyectoViewModel();
            /* ------------------------------Cargada items para el menu ------------------- */
            vProyectoViewModel.eListaProyecto = new Business.Proyecto().GetListaProyecto().ToList();

            return vProyectoViewModel.eListaProyecto;
        }

        /* ********************************************* Return view Crear ************************************************** */
        [HttpGet]
        public IActionResult Crear(int Id)
        {
            try
            {
                ProyectoViewModel vProyectoViewModel = new ProyectoViewModel();

                Business.Proyecto oProyecto = new Business.Proyecto();



                if (Id != 0)
                {
                    vProyectoViewModel.eProyecto = oProyecto.GetProyecto(Id);
                }
                else
                {
                    vProyectoViewModel.eProyecto = new Entities.Proyecto();
                }

                return View(vProyectoViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /* ********************************************* Para inserar y editar ************************************************** */
        [HttpPost]
        public IActionResult Post(ProyectoViewModel vProyectoViewModel)
        {
            try
            {
                Business.Proyecto oProyecto = new Business.Proyecto();

                if (vProyectoViewModel.eProyecto.UserId != 0)
                {
                    oProyecto.Modificar(vProyectoViewModel.eProyecto);
                }
                else
                {
                    oProyecto.Guardar(vProyectoViewModel.eProyecto);
                }
            }
            catch (Exception ex)
            {

                return Ok(new { Result = false });
                throw ex;
            }
            return Ok(new { Result = true });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Business.Proyecto oUsuario = new Business.Proyecto();
            oUsuario.Eliminar(id);

            return Ok(new { Result = true });
        }
    }
}
