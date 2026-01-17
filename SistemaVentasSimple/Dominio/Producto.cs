using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }


        public Producto() { }

        public Producto(int idProducto, string nombre, string marca, string descripcion, decimal precio, int stock, bool estado)
        {
            IdProducto = idProducto;
            Nombre = nombre;
            Marca = marca;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            Estado = estado;
        }
    }
}
