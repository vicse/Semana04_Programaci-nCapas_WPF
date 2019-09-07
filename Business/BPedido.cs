using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Business
{
    public class BPedido
    {

        private DPedido DPedido = null;
        public List<Pedido> GetPedidosEntreFechas(DateTime FechaInicio, DateTime FechaFin)
        {
            List<Pedido> pedidos = null;
            try
            {
                DPedido = new DPedido();
                pedidos = DPedido.GetPedidos(new Pedido { FechaInicio = FechaInicio, FechaFin = FechaFin });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pedidos;
        }
    }
}
