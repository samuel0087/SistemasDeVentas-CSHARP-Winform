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
        public List<Venta> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Venta> lista = new List<Venta>();
            ClienteNegocio cNegocio = new ClienteNegocio();
            string query = "";

            try
            {
                datos.setearConsulta(query);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.IdVenta = datos.Lector["IdVenta"] is DBNull ? 0 : (int)datos.Lector["IdVneta"];
                    aux.Fecha = datos.Lector["Fecha"] is DBNull ? new DateTime() : (DateTime)datos.Lector["Fecha"];
                    aux.MontoFinal = datos.Lector["MontoFinal"] is DBNull ? 0 : (decimal)datos.Lector["MontoFinal"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IdCliente = datos.Lector["IdCliente"] is DBNull ? 0 : (int)datos.Lector["IdCliente"];

                    if(aux.Cliente.IdCliente != 0) 
                    {
                        aux.Cliente = cNegocio.BuscarPorId(aux.Cliente.IdCliente);
                    }

                    lista.Add(aux);
                }

                return lista;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al listar ventas", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
    /*
        •	Agregar: Recibe un Objeto Venta y no devuelve nada.
        •	ValidarStock: Recibe un IdProducto y una cantidad. Devuelve bool.
        •	ActualizarStock: Recibe un IdProducto y una cantidad. No devuelve nada.
        •   CalcularMontoFinal: Recibe un objeto ProductoVenta y devuelve un decimal.

     */
}
