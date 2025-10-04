﻿using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
   public interface IPedidoBuilder
    {
        IPedidoBuilder ConItems(IEnumerable<(string sku,string nombre, decimal precio, int cantidad)>items);
        IPedidoBuilder ConDireccion(string direccion);
        IPedidoBuilder ConMetodoPago(string tipoPago);
        // "tarjeta", "mp", "transf", "adapter"
        Pedido Build();


    }
}
