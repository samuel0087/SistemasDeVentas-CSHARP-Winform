using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Conexion;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Producto> lista = new List<Producto>();
            string query = "  SELECT IdProducto, Codigo, Nombre, Marca, Descripcion, Precio, Stock, Estado FROM Productos WHERE Estado = 1";

            try
            {
                datos.setearConsulta(query);
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.IdProducto = datos.Lector["IdProducto"] is DBNull ? 0 : (int)datos.Lector["IdProducto"];
                    aux.Codigo = datos.Lector["Codigo"] is DBNull ? "" : (string)datos.Lector["Codigo"];
                    aux.Nombre = datos.Lector["Nombre"] is DBNull ? "" : (string)datos.Lector["Nombre"];
                    aux.Descripcion = datos.Lector["Descripcion"] is DBNull ? "" : (string)datos.Lector["Descripcion"];
                    aux.Marca = datos.Lector["Marca"] is DBNull ? "" : (string)datos.Lector["Marca"];
                    aux.Precio = datos.Lector["Precio"] is DBNull ? 0 : (decimal)datos.Lector["Precio"];
                    aux.Stock = datos.Lector["Stock"] is DBNull ? 0 : (int)datos.Lector["Stock"];
                    aux.Estado = datos.Lector["Estado"] is DBNull ? false : (bool)datos.Lector["Estado"];
                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar productos", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Agregar(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "INSERT INTO Productos (Codigo, Nombre, Marca, Descripcion, Precio, Stock, Estado) VALUES (@codigo, @nombre, @marca, @descripcion, @precio, @stock, @estado)";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@codigo", producto.Codigo);
                datos.setearParametro("@nombre", producto.Nombre);
                datos.setearParametro("@marca", producto.Marca);
                datos.setearParametro("@descripcion", producto.Descripcion);
                datos.setearParametro("@precio", producto.Precio);
                datos.setearParametro("@stock", producto.Stock);
                datos.setearParametro("@estado", true);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el producto", ex );
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "UPDATE Productos SET Codigo = @codigo, Nombre = @nombre, Marca = @marca, Descripcion = @descripcion, Precio = @precio, Stock = @stock, Estado = @estado WHERE IdProducto = @id";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@codigo", producto.Codigo);
                datos.setearParametro("@nombre", producto.Nombre);
                datos.setearParametro("@marca", producto.Marca);
                datos.setearParametro("@descripcion", producto.Descripcion);
                datos.setearParametro("@precio", producto.Precio);
                datos.setearParametro("@stock", producto.Stock);
                datos.setearParametro("@estado", producto.Estado);
                datos.setearParametro("@id", producto.IdProducto);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el producto", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Eliminar (int id)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "UPDATE Productos SET Estado = 0 WHERE IdProducto = @id";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@id", id);

                datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al eliminar producto", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ActualizarStock(Producto producto, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "UPDATE Productos SET Stock += @cantidad WHERE IdProducto = @id";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@cantidad", cantidad);
                datos.setearParametro("@id", producto.IdProducto);
                datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al actualizar stock de productos", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }

    /*
        •	ActualizarStock: Recibe un Producto y una cantidad, no devuelve nada.

     */
}
