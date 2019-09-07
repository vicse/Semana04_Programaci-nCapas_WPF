using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class DDetallePedido
    {
        public List<DetallePedido> GetDetallePedidos(DetallePedido detallePedido)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            List<DetallePedido> DetallesPedidos = null;

            try
            {
                commandText = "Usp_Detalle_Pedido";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idpedido", SqlDbType.Int);
                parameters[0].Value = detallePedido.Pedido.IdPedido;
                DetallesPedidos = new List<DetallePedido>();

                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, commandText,
                    CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        DetallesPedidos.Add(new DetallePedido
                        {
                            idpedido = reader["idpedido"] != null ? Convert.ToInt32(reader["idpedido"]) : 0,
                            idproducto = reader["idproducto"] != null ? Convert.ToInt32(reader["idproducto"]) : 0,
                            preciounidad = reader["preciounidad"] != null ? Convert.ToDecimal(reader["preciounidad"]) : 0,
                            cantidad = reader["cantidad"] != null ? Convert.ToInt32(reader["cantidad"]) : 0,
                            descuento = reader["descuento"] != null ? Convert.ToDecimal(reader["descuento"]) : 0
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return DetallesPedidos;
        }
    }
}
