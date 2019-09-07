using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Business;
using Entity;

namespace Semana4
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            BPedido bPedido = null;
            try
            {
                bPedido = new BPedido();
                dvgPedido.ItemsSource = bPedido.GetPedidosEntreFechas(Convert.ToDateTime(txtFechaInicio.Text),
                                                                      Convert.ToDateTime(txtFechaFin.Text));
            }
            catch (Exception )
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                bPedido = null;
            }
        }

        private void DgvPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BDetallePedido bDetallePedido = null;
            try
            {
                int idpedido;
                Pedido pedido = (Pedido)dvgPedido.SelectedItem;
                idpedido = pedido.IdPedido;
                //var item = dgvPedido.SelectedItems as DataRowView;
                //if (item == null) return;
                //idpedido = Convert.ToInt32(item.Row["IdPedido"]);
                bDetallePedido = new BDetallePedido();

                dvgDetallePedido.ItemsSource = bDetallePedido.GetDetallePedidosPorId(idpedido);
               txtTotal.Text = bDetallePedido.GetDetalleTotalPorId(idpedido).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                bDetallePedido = null;
            }
        }
    }
}
