using Conexion;
using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Cliente> lista = new List<Cliente>();
            string query = "SELECT IdCliente, Nombre, Apellido, Dni, Telefono, Email, Estado FROM Clientes WHERE Estado = 1";

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
            catch(Exception ex){
                throw new Exception("Error al listar los clientes", ex);
            }
            finally 
            {
                datos.cerrarConexion();
            }
        }

        public Cliente BuscarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "SELECT IdCliente, Nombre, Apellido, Dni, Telefono, Email, Estado FROM Clientes WHERE IdCliente = @id";
            Cliente aux = new Cliente();
            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    aux.IdCliente = datos.Lector["IdCliente"] is DBNull ? 0 : (int)datos.Lector["IdCliente"];
                    aux.Nombre = datos.Lector["Nombre"] is DBNull ? "" : (string)datos.Lector["Nombre"];
                    aux.Apellido = datos.Lector["Apellido"] is DBNull ? "" : (string)datos.Lector["Apellido"];
                    aux.Dni = datos.Lector["Dni"] is DBNull ? "" : (string)datos.Lector["Dni"];
                    aux.Email = datos.Lector["Email"] is DBNull ? "" : (string)datos.Lector["Email"];
                    aux.Telefono = datos.Lector["Telefono"] is DBNull ? "" : (string)datos.Lector["Telefono"];
                    aux.Estado = datos.Lector["Estado"] is DBNull ? false : (bool)datos.Lector["Estado"];
                }
                else
                {
                    return null;
                }

                return aux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al bucar el cliente", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Agregar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "INSERT INTO Clientes (Nombre, Apellido, Dni, Email, Telefono, Estado) VALUES (@nombre, @apellido, @dni, @email, @telefono, @estado)";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@nombre", cliente.Nombre);
                datos.setearParametro("@apellido", cliente.Apellido);
                datos.setearParametro("@dni", cliente.Dni);
                datos.setearParametro("@email", cliente.Email);
                datos.setearParametro("@telefono", cliente.Telefono);
                datos.setearParametro("@estado", cliente.Estado);
                datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al agregar el cliente", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "UPDATE Clientes SET Nombre = @nombre, Apellido = @apellido, Dni = @dni, Email = @email, Telefono = @telefono WHERE IdCliente = @id";

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
            catch(Exception ex)
            {
                throw new Exception("Error al modificar el cliente", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "UPDATE Clientes SET Estado = 0 WHERE IdCliente = @id";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar eliminar al cliente", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool ExisteCliente(string dni)
        {
            AccesoDatos datos = new AccesoDatos();
            string query = "SELECT IdCliente FROM Clientes WHERE Dni = @dni AND Estado = 1";

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
            catch(Exception ex)
            {
                throw new Exception("Error al intentar verificar la existencia del cliente", ex );
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Cliente> Buscar(string dni)
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();
            string query = "SELECT IdCliente, Nombre, Apellido, Dni, Telefono, Email, Estado FROM Clientes WHERE Estado = 1 AND Dni LIKE @filtro";

            try
            {
                datos.setearConsulta(query);
                datos.setearParametro("@filtro", $"%{dni}%");
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
            catch(Exception ex) 
            {
                throw new Exception("Error al buscar cliente por dni", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Cliente> BuscarConFiltro(string filtro)
        {
            List<Cliente> listaFiltrada = new List<Cliente>();
            try
            {
                listaFiltrada = this.Listar().FindAll(cliente => cliente.Nombre.ToUpper().Contains(filtro.ToUpper()) || cliente.Apellido.ToUpper().Contains(filtro.ToUpper()) || cliente.Dni.Contains(filtro));
                return listaFiltrada;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar clientes con filtros", ex);
            }
        }

    }

}
