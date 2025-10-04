using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveyGo.Clases
{
    public class ItemCarrito
    {        
            public string SKU { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int Cantidad { get; set; }
            public decimal Subtotal => Precio * Cantidad;

            public ItemCarrito(string sku, string nombre, decimal precio, int cantidad)
            {
                SKU = sku;
                Nombre = nombre;
                Precio = precio;
                Cantidad = cantidad;
            }

            public ItemCarrito Clone()
            {
                return new ItemCarrito(SKU, Nombre, Precio, Cantidad);
            }
        
    }
}
