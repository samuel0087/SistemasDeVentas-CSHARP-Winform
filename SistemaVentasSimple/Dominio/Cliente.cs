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
        public string telefono { get; set; }
        public string email { get; set; }
        public bool Estado { get; set; }

        public Cliente() { }
        
        public Cliente(int id, string nombre, string Apellido, string dni,  string telefono, string email) 
        {
            this.IdCliente = id;
            this.Nombre = nombre;
            this.Apellido = Apellido;
            this.Dni = Dni;
            this.telefono = telefono;
            this.email = email;
        }

    }
}
