using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;


namespace Business
{
    public class BDetallePedido
    {
        private DDetallePedido DDetallePedido = null;

        public List<DetallePedido> GetDetallePedidosPorId(int IdPedido)
        {
            List<DetallePedido> DetallePedidos = null;

            try
            {
                DDetallePedido = new DDetallePedido();
                DetallePedidos = DDetallePedido.GetDetallePedidos(new DetallePedido
                {
                    Pedido = new Pedido
                    {
                        IdPedido = IdPedido
                    }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DDetallePedido = null;
            }
            return DetallePedidos;
        }

        public decimal GetDetalleTotalPorId(int IdPedido)
        {
            List<DetallePedido> DetallePedidos = null;
            decimal total = 0;

            try
            {
                DDetallePedido = new DDetallePedido();
                DetallePedidos = DDetallePedido.GetDetallePedidos(new DetallePedido
                {
                    Pedido = new Pedido
                    {
                        IdPedido = IdPedido
                    }
                });

                foreach (var item in DetallePedidos)
                {
                    total = total + item.cantidad * item.preciounidad - item.descuento;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DDetallePedido = null;
            }
            return total;
        }
    }

}