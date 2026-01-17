using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ProductoVenta
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal MontoFinal { get; set; }

        public ProductoVenta() { }
        public ProductoVenta(Producto producto, int cantidad) 
        {
            Producto = producto;
            Cantidad = cantidad;
        }

    }
}
