using DeliveyGo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces; 

namespace Clases
{
    public class NotificadorCliente
    {
        private string _nombreCliente;

        public NotificadorCliente(string nombreCliente)
        {
            _nombreCliente = nombreCliente;
        }

        public void SuscribirseA(PedidoService servicio)
        {
            servicio.EstadoCambiado += OnEstadoCambiado;
        }

        private void OnEstadoCambiado(object sender, PedidoChangedEventArgs e)
        {
            Console.WriteLine($"[NOTIF CLIENTE - {_nombreCliente}] 📧 Tu pedido #{e.PedidoId} ahora está: {e.NuevoEstado}");

            switch (e.NuevoEstado)
            {
                case EstadoPedido.Preparando:
                    Console.WriteLine($"   → Estamos preparando tu pedido con cuidado");
                    break;
                case EstadoPedido.Enviado:
                    Console.WriteLine($"   → ¡Tu pedido está en camino!");
                    break;
                case EstadoPedido.Entregado:
                    Console.WriteLine($"   → ¡Pedido entregado! Gracias por tu compra");
                    break;
            }
        }
    }
}
