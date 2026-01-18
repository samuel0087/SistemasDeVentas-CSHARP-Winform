using Conexion;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Cliente> lista = new List<Cliente>();
            string query = "";

            try
            {
                datos.setearConsulta(query);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.IdCliente = datos.Lector["IdCliente"] is DBNull ? 0 : (int)datos.Lector["IdCliente"];
                    aux.Nombre = datos.Lector["Nombre"] is DBNull ? "" : (string)datos.Lector["Nombre"];
                    aux.Apellido = datos.Lector["Apellido"] is DBNull ? "" : (string)datos.Lector["Apellido"];
                    aux.Dni = datos.Lector["Dni"] is DBNull ? "" : (string)datos.Lector["Dni"];
                    aux.Email = datos.Lector["Email"] is DBNull ? "" : (string)datos.Lector["Email"];
                    aux.Telefono = datos.Lector["Telefono"] is DBNull ? "" : (string)datos.Lector["Telefono"];
                    aux.Estado = datos.Lector["Estado"] is DBNull ? false : (bool)datos.Lector["Estado"];

                    lista.Add(aux);
                }

                return lista;
            }
            finally 
            {
                datos.cerrarConexion();
            }
        }

        public void Agregar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@nombre", cliente.Nombre);
                datos.setearParametro("@apellido", cliente.Apellido);
                datos.setearParametro("@dni", cliente.Dni);
                datos.setearParametro("@email", cliente.Email);
                datos.setearParametro("@telefono", cliente.Telefono);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@nombre", cliente.Nombre);
                datos.setearParametro("@apellido", cliente.Apellido);
                datos.setearParametro("@dni", cliente.Dni);
                datos.setearParametro("@email", cliente.Email);
                datos.setearParametro("@telefono", cliente.Telefono);
                datos.setearParametro("@id", cliente.IdCliente);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool ExisteCliente(string dni)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@dni", dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return true;
                }

                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }

//•	Buscar: Recibe un string y devuelve un listado de clientes. //

}
