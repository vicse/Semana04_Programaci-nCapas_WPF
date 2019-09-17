using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Business;
using Entity;

namespace Semana4
{
    /// <summary>
    /// Lógica de interacción para ListaCategoria.xaml
    /// </summary>
    public partial class ListaCategoria : Window
    {
        public ListaCategoria()
        {
            InitializeComponent();
        }

        private void Cargar()
        {
            BCategoria Bcategoria = null;
            try
            {
                //:0 Listar todas las categorias
                Bcategoria = new BCategoria();
                dgvCategoria.ItemsSource = Bcategoria.Listar(0);
            }
            catch (Exception)
            {
                MessageBox.Show("Comnunicarse con el Administrador ");
            }
            finally
            {
                Bcategoria = null;
            }

        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            AgregarCategoria agregarCategoria = new AgregarCategoria(0);
            agregarCategoria.ShowDialog();
            Cargar();
        }

        private void DgvCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idCategoria;
            var item = (Categoria)dgvCategoria.SelectedItem;
            if (null == item) return;
            idCategoria = Convert.ToInt32(item.IdCatgoria);
            //Coloco 0 porque es uno nuevo
            AgregarCategoria agregarCategoria = new AgregarCategoria(idCategoria);
            agregarCategoria.ShowDialog();
            Cargar();
        }

        private void BtnConsultar_Click_1(object sender, RoutedEventArgs e)
        {
            Cargar();

        }
    }
}
