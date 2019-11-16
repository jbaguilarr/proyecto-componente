using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Data;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class Proyecto
    {

        ApplicationDbContext _DBcontext;

        #region OPERACIONES BASICAS GUARDAR, MODIFICAR Y ELIMINAR


        public Proyecto()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer("Server=NEIDY;User ID=sa;Password=123;Database=DeliveryTrackerDB;");
            //optionsBuilder.UseSqlServer("Server=.\\LaptopALC2016;User ID=sa;Password=laptop123.;Database=bd_MovieClub;");
            // optionsBuilder.UseNpgsql("Host=localhost;Port=5432;User ID=postgres;Password=laptop123.;Database=db_facturacion;");

            _DBcontext = new ApplicationDbContext(optionsBuilder.Options);

        }


        public bool Guardar(Entities.Proyecto eProyecto)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    //tregistrando empresa
                    this._DBcontext.Proyecto.Add(eProyecto);
                    this._DBcontext.SaveChanges();

                    oTrans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    oTrans.Rollback();
                    throw ex;
                }
            }
        }

        public bool Modificar(Entities.Proyecto eProyecto)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    Entities.Proyecto eProyectoAux = this._DBcontext.Proyecto.FirstOrDefault(e => e.ProyectoId == eProyecto.ProyectoId);
                    eProyectoAux.Nombre = eProyecto.Nombre;
                    eProyectoAux.Descripcion = eProyecto.Descripcion;
                    eProyectoAux.UserId = eProyecto.UserId;

                    this._DBcontext.Entry(eProyectoAux).State = EntityState.Modified;
                    this._DBcontext.SaveChanges();



                    oTrans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    oTrans.Rollback();
                    throw ex;
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    Entities.Proyecto eProyecto = this.GetProyecto(id);

                    //oTrans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    oTrans.Rollback();
                    throw ex;
                }
            }
        }

        #endregion

        #region metodos get, listado, etc
        public Entities.Proyecto GetProyecto(int id_Proyecto)
        {
            try
            {
                return this._DBcontext.Proyecto.FirstOrDefault(e => e.ProyectoId == id_Proyecto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Entities.Proyecto> GetListaProyecto()
        {
            try
            {
                return this._DBcontext.Proyecto.OrderByDescending(e => e.ProyectoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<Entities.Usuario> GetListaUsuario()
        //{
        //    try
        //    {
        //        return this._DBcontext.Usuario.OrderByDescending(e => e.id_usuario).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion

        //public Entities.Usuario Login(string correo, string contrasena)
        //{
        //    try
        //    {
        //        Entities.Usuario eMovie = _DBcontext.Usuario.Where(u => u.user_name == correo && u.contrasena == contrasena).Single();
        //        return eMovie;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }


}
