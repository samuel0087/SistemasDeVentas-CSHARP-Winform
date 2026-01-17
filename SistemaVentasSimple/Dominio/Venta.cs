using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public ProductoVenta Productos { get; set; }
        public decimal MontoFinal { get; set; }

        public Venta() { }

        public Venta(int idVenta, Cliente cliente, DateTime fecha, ProductoVenta productos, decimal montoFinal)
        {
            IdVenta = idVenta;
            Cliente = cliente;
            Fecha = fecha;
            Productos = productos;
            MontoFinal = montoFinal;
        }
    }
}
