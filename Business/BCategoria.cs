using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;


namespace Business
{
    public class BCategoria
    {

        private DCategoria DCategoria = null;

        public List<Categoria> Listar(int IdCategoria)
        {
            List<Categoria> categorias = null;
            try
            {
                DCategoria = new DCategoria();
                categorias = DCategoria.Listar(new Categoria { IdCatgoria = IdCategoria });
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return categorias;
        }

        public bool Insertar(Categoria categoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                categoria.IdCatgoria = DCategoria.Listar(new Categoria { IdCatgoria = 0 }).Max(x => x.IdCatgoria) + 1;
                DCategoria.Insertar(categoria);
            }
            catch (Exception ex)
            {
                //Escribir en el log
                result = false;
                //throw ex;
            }
            return result;
        }

        public bool Actualizar(Categoria categoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Actualizar(categoria);
            }
            catch (Exception ex)
            {
                //Escribir en el log
                result = false;
                //throw ex;
            }
            return result;
        }
        public bool Eliminar(int IdCategoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Eliminar(IdCategoria);
            }
            catch (Exception)
            {
                //Escribir en el log
                result = false;
                //throw ex;
            }
            return result;
        }

    }
}
