using DeliveyGo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{
    public class PedidoService
    {
        private List<Pedido> _pedidos;

        public event EventHandler<PedidoChangedEventArgs> EstadoCambiado;

        public PedidoService()
        {
            _pedidos = new List<Pedido>();
        }

        public void AgregarPedido(Pedido pedido)
        {
            _pedidos.Add(pedido);
            Console.WriteLine($"[PEDIDO SERVICE] Pedido #{pedido.Id} agregado al sistema");
        }

        public void CambiarEstado(int pedidoId, EstadoPedido nuevoEstado)
        {
            var pedido = _pedidos.FirstOrDefault(p => p.Id == pedidoId);

            if (pedido == null)
            {
                Console.WriteLine($"[PEDIDO SERVICE] ✗ Pedido #{pedidoId} no encontrado");
                return;
            }

            EstadoPedido estadoAnterior = pedido.Estado;
            pedido.Estado = nuevoEstado;
            pedido.UltimaActualizacion = DateTime.Now;

            Console.WriteLine($"[PEDIDO SERVICE] Pedido #{pedidoId}: {estadoAnterior} → {nuevoEstado}");

            // Notificar a los observadores
            if (EstadoCambiado != null)
            {
                EstadoCambiado.Invoke(this, new PedidoChangedEventArgs(pedidoId, nuevoEstado, DateTime.Now));
            }
        }

        public Pedido ObtenerPedido(int id)
        {
            return _pedidos.FirstOrDefault(p => p.Id == id);
        }

        public List<Pedido> ObtenerTodosPedidos()
        {
            return new List<Pedido>(_pedidos);
        }

        public List<Pedido> ObtenerPedidosPorEstado(EstadoPedido estado)
        {
            return _pedidos.Where(p => p.Estado == estado).ToList();
        }

        public int CantidadPedidos()
        {
            return _pedidos.Count;
        }
    }
}

