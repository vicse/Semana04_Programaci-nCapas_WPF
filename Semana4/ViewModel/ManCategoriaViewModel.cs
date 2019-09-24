using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Semana4.Model;
using System.Windows;
using System.Windows.Input;

namespace Semana4.ViewModel
{
    public class ManCategoriaViewModel: ViewModelBase
    {

        #region propiedades
        int _ID;

        public int ID
        {
            get { return _ID; }
            set
            {
                if ( _ID != value)
                {
                    _ID = value;
                    onPropertyChanged();
                }
            }
        }

        string _Nombre;

        public string Nombre
        {
            get { return _Nombre ; }
            set
            {
                if (_Nombre != value)
                {
                    _Nombre = value;
                    onPropertyChanged();
                }
            }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set
            {
                if (_Descripcion != value)
                {
                    _Descripcion = value;
                    onPropertyChanged();
                }
            }
        }

        #endregion

        public ICommand GrabarCommand { get; set; }

        public ICommand CerrarCommand { get; set; }

        public ManCategoriaViewModel()
        {
            GrabarCommand = new RelayCommand<Window>(
                o =>
                {

                    if (ID > 0)
                        new CategoriaModel().Actualizar(new Entity.Categoria
                        {
                            IdCatgoria = ID,
                            NombreCategoria = Nombre,
                            Descripcion = Descripcion


                        });
                    else
                        new CategoriaModel().Insertar(new Entity.Categoria
                        {
                            NombreCategoria = Nombre,
                            Descripcion = Descripcion
                          
                        });

                    o.Close();

                });

            CerrarCommand = new RelayCommand<Window>(
                param => Cerrar(param)
                );
        }

        void Cerrar(Window window)
        {
            window.Close();
        }
    }
}
