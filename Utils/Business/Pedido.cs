using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Data;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class Pedido
    {
        ApplicationDbContext _DBcontext;

        #region OPERACIONES BASICAS GUARDAR, MODIFICAR Y ELIMINAR


        public Pedido()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer("Server=NEIDY;User ID=sa;Password=123;Database=DeliveryTrackerDB;");
            //optionsBuilder.UseSqlServer("Server=.\\LaptopALC2016;User ID=sa;Password=laptop123.;Database=bd_MovieClub;");
            // optionsBuilder.UseNpgsql("Host=localhost;Port=5432;User ID=postgres;Password=laptop123.;Database=db_facturacion;");

            _DBcontext = new ApplicationDbContext(optionsBuilder.Options);

        }


        public bool Guardar(Entities.Pedido ePedido)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    //tregistrando empresa
                    this._DBcontext.Pedido.Add(ePedido);
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

        public bool Modificar(Entities.Pedido ePedido)
        {
            using (var oTrans = _DBcontext.Database.BeginTransaction())
            {
                try
                {
                    Entities.Pedido ePedidoAux = this._DBcontext.Pedido.FirstOrDefault(e => e.PedidoId == ePedido.PedidoId);
                    ePedidoAux.ProyectoId = ePedido.ProyectoId;
                    ePedidoAux.Codigo = ePedido.Codigo;
                    ePedidoAux.FechaCreacion = ePedido.FechaCreacion;
                    ePedidoAux.Descripcion = ePedido.Descripcion;
                    ePedidoAux.Observaciones = ePedido.Observaciones;
                    ePedidoAux.Estado = ePedido.Estado;
                    ePedidoAux.FechaEntregado = ePedido.FechaEntregado;
                    ePedidoAux.Latitud = ePedido.Latitud;
                    ePedidoAux.Longitud = ePedido.Longitud;

                    this._DBcontext.Entry(ePedidoAux).State = EntityState.Modified;
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
                    Entities.Pedido ePedido = this.GetPedido(id);

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
        public Entities.Pedido GetPedido(int id_Pedido)
        {
            try
            {
                return this._DBcontext.Pedido.FirstOrDefault(e => e.PedidoId == id_Pedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Entities.Pedido> GetListaPedido()
        {
            try
            {
                return this._DBcontext.Pedido.OrderByDescending(e => e.PedidoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
