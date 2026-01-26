using System;
using System.Collections.Generic;
using Dominio;
using Conexion;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentaNegocio
    {
        private AccesoDatos datos = new AccesoDatos();
        public List<Venta> Listar()
        {
            List<Venta> lista = new List<Venta>();
            ClienteNegocio cNegocio = new ClienteNegocio();
            string query = "SELECT IdVenta, IdCliente, Fecha, MontoFinal FROM Ventas";

            try
            {
                datos.setearConsulta(query);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.IdVenta = datos.Lector["IdVenta"] is DBNull ? 0 : (int)datos.Lector["IdVenta"];
                    aux.Fecha = datos.Lector["Fecha"] is DBNull ? new DateTime() : (DateTime)datos.Lector["Fecha"];
                    aux.MontoFinal = datos.Lector["MontoFinal"] is DBNull ? 0 : (decimal)datos.Lector["MontoFinal"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IdCliente = datos.Lector["IdCliente"] is DBNull ? 0 : (int)datos.Lector["IdCliente"];

                    if (aux.Cliente.IdCliente != 0)
                    {
                        aux.Cliente = cNegocio.BuscarPorId(aux.Cliente.IdCliente);
                    }

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar ventas", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private Venta Agregar(Venta venta)
        {
            string query = "INSERT INTO Ventas(IdCliente, Fecha, MontoFinal) VALUES (@id, @fecha, @monto); SELECT SCOPE_IDENTITY();";


            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@id", venta.Cliente.IdCliente);
                datos.setearParametro("@fecha", venta.Fecha);
                datos.setearParametro("@monto", venta.MontoFinal);

                venta.IdVenta = Convert.ToInt32(datos.ejecutarEscalar());

                return venta;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la venta", ex);
            }
        }

        private bool ValidarStock(int id, int cantidad)
        {
            string query = "  SELECT IdProducto FROM Productos WHERE Estado = 1 AND IdProducto = @id AND Stock >= @cantidad";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@id", id);
                datos.setearParametro("@cantidad", cantidad);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("error al validar stock", ex);
            }
        }

        private void ActualizarStock(Producto producto, int cantidad)
        {
            ProductoNegocio pNegocio = new ProductoNegocio();
            pNegocio.ActualizarStock(producto, cantidad * -1);

        }

        private decimal CalcularMontoFinal(List<ProductoVenta> carrito)
        {
            try
            {
                decimal montoFinal = carrito.Sum(c => c.MontoTotal);
                return montoFinal;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al calcular motofinal", ex);
            }
        }

        private void RegistrarProductoXVenta(Venta venta)
        {
            string query = "INSERT INTO ProductosXVentas (IdVenta, IdProducto, Cantidad, MontoTotal) VALUES(@idVenta, @idProducto, @cantidad, @montoTotal);";

            try
            {
                datos.setearConsulta(query);

                foreach( ProductoVenta producoXventa in venta.Productos)
                {
                    datos.limpiarParametros();
                    datos.setearParametro("@idVenta", venta.IdVenta);
                    datos.setearParametro("@idProducto", producoXventa.Producto.IdProducto);
                    datos.setearParametro("@cantidad", producoXventa.Cantidad);
                    datos.setearParametro("@montoTotal", producoXventa.MontoTotal);

                    datos.ejecutarAccion();
                }

            }
            catch(Exception ex)
            {
                throw new Exception("Error al registrar los productos vendidos", ex);
            }
        }
        
    }

    /*
     * Agregar un método VentaNegocio.RegistrarProductosXVenta
     * Función del método: Recibe un objeto venta y no devuelve nada.
     * Descripción: Este método se utilizara para registrar todos los productos por venta en la tabla ProductoXventas junto al IdVenta
     */
}
