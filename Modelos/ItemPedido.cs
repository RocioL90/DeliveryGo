using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ItemPedido
    {
        public string SKU { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => Precio * Cantidad;

        public ItemPedido(string sku, string nombre, decimal precio, int cantidad)
        {
            SKU = sku;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        public override string ToString()
        {
            return $"{Nombre} x{Cantidad} = ${Subtotal:N2}";
        }
    }
}
