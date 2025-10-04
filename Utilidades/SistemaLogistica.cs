using DeliveyGo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{
    public class SistemaLogistica
    {
        public void SuscribirseA(PedidoService servicio)
        {
            servicio.EstadoCambiado += OnEstadoCambiado;
        }

        private void OnEstadoCambiado(object sender, PedidoChangedEventArgs e)
        {
            if (e.NuevoEstado == EstadoPedido.Preparando)
            {
                Console.WriteLine($"[LOGÍSTICA] 📦 Pedido #{e.PedidoId} listo para envío - Asignando transportista...");
            }
            else if (e.NuevoEstado == EstadoPedido.Enviado)
            {
                Console.WriteLine($"[LOGÍSTICA] 🚚 Pedido #{e.PedidoId} en ruta - Tracking activado");
            }
        }
    }
}
