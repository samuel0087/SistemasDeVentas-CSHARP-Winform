using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }

        public Cliente() { }
        
        public Cliente(int id, string nombre, string apellido, string dni,  string telefono, string email, bool estado) 
        {
            IdCliente = id;
            Nombre = nombre;
            Apellido = Apellido;
            Dni = Dni;
            Telefono = telefono;
            Email = email;
            Estado = estado;
        }

    }
}
