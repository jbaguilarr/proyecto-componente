using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Data;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class Entregador
    {
        ApplicationDbContext _DBcontext;

        #region OPERACIONES BASICAS GUARDAR, MODIFICAR Y ELIMINAR


        public Entregador()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer("Server=NEIDY;User ID=sa;Password=123;Database=DeliveryTrackerDB;");
            //optionsBuilder.UseSqlServer("Server=.\\LaptopALC2016;User ID=sa;Password=laptop123.;Database=bd_MovieClub;");
            // optionsBuilder.UseNpgsql("Host=localhost;Port=5432;User ID=postgres;Password=laptop123.;Database=db_facturacion;");

            _DBcontext = new ApplicationDbContext(optionsBuilder.Options);

        }


        public bool Guardar(Entities.Entregador eEntregador)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    //tregistrando empresa
                    this._DBcontext.Entregador.Add(eEntregador);
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

        public bool Modificar(Entities.Entregador eEntregador)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    Entities.Entregador eEntregadorAux = this._DBcontext.Entregador.FirstOrDefault(e => e.EntregadorId == eEntregador.EntregadorId);
                    eEntregadorAux.Codigo = eEntregador.Codigo;
                    eEntregadorAux.Nombre = eEntregador.Nombre;
                    eEntregadorAux.Telefono = eEntregador.Telefono;
                    eEntregadorAux.ProyectoId = eEntregador.ProyectoId;

                    this._DBcontext.Entry(eEntregadorAux).State = EntityState.Modified;
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
                    Entities.Entregador eEntregador = this.GetEntregador(id);

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
        public Entities.Entregador GetEntregador(int id_Entregador)
        {
            try
            {
                return this._DBcontext.Entregador.FirstOrDefault(e => e.EntregadorId == id_Entregador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Entities.Entregador> GetListaEntregador()
        {
            try
            {
                return this._DBcontext.Entregador.OrderByDescending(e => e.EntregadorId);
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
