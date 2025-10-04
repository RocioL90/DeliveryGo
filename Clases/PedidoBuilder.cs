using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Interfaces.IPago;

namespace Clases
{
    public class PedidoBuilder : IPedidoBuilder
    {
        private Pedido _pedido;

        public PedidoBuilder()
        {
            _pedido = new Pedido();
        }

        public IPedidoBuilder ConItems(IEnumerable<(string sku, string nombre, decimal precio, int cantidad)> items)
        {
            _pedido.Items.Clear();

            foreach (var item in items)
            {
                var itemPedido = new ItemPedido(item.sku, item.nombre, item.precio, item.cantidad);
                _pedido.Items.Add(itemPedido);
            }

            // Calcular subtotal
            _pedido.Subtotal = _pedido.Items.Sum(i => i.Subtotal);

            return this;
        }

        public IPedidoBuilder ConDireccion(string direccion)
        {
            _pedido.Direccion = direccion;
            return this;
        }

        public IPedidoBuilder ConMetodoPago(string tipoPago)
        {
            _pedido.MetodoPago = tipoPago;
            return this;
        }

        public IPedidoBuilder ConCostoEnvio(decimal costoEnvio)
        {
            _pedido.CostoEnvio = costoEnvio;
            return this;
        }

        public IPedidoBuilder ConTotal(decimal total)
        {
            _pedido.Total = total;
            return this;
        }

        public IPedidoBuilder ConEstado(EstadoPedido estado)
        {
            _pedido.Estado = estado;
            return this;
        }

        public Pedido Build()
        {
            // Validaciones antes de construir
            if (_pedido.Items.Count == 0)
                throw new InvalidOperationException("El pedido debe tener al menos un item");

            if (string.IsNullOrWhiteSpace(_pedido.Direccion))
                throw new InvalidOperationException("El pedido debe tener una dirección");

            if (string.IsNullOrWhiteSpace(_pedido.MetodoPago))
                throw new InvalidOperationException("El pedido debe tener un método de pago");

            // Si no se especificó el total, calcularlo
            if (_pedido.Total == 0)
            {
                _pedido.Total = _pedido.Subtotal + _pedido.CostoEnvio;
            }

            _pedido.UltimaActualizacion = DateTime.Now;

            // Retornar el pedido construido
            Pedido pedidoFinal = _pedido;

            // Reiniciar builder para futuras construcciones
            _pedido = new Pedido();

            return pedidoFinal;
        }
    }
}

