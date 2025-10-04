using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Producto
    {
        
        public string SKU { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Producto(string sku, string nombre, decimal precio)
        {
            SKU = sku;
            Nombre = nombre;
            Precio = precio;
        }
    }
}

