using DeliveyGo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Interfaces.IPago;
using Interfaces;

namespace Clases
{
    public class SistemaAnaliticas
    {
        private int _pedidosEntregados = 0;

        public void SuscribirseA(PedidoService servicio)
        {
            servicio.EstadoCambiado += OnEstadoCambiado;
        }

        private void OnEstadoCambiado(object sender, PedidoChangedEventArgs e)
        {
            if (e.NuevoEstado == EstadoPedido.Entregado)
            {
                _pedidosEntregados++;
                Console.WriteLine($"[ANALÍTICAS] 📊 Pedido #{e.PedidoId} entregado - Actualizando métricas...");
            }
        }

        public void MostrarEstadisticas()
        {
            Console.WriteLine($"\n=== ESTADÍSTICAS ===");
            Console.WriteLine($"Pedidos entregados exitosamente: {_pedidosEntregados}");
        }
    }
}

