using System;
using Interfaces;

namespace Clases
{
    public class PedidoChangedEventArgs : EventArgs
    {
        public int PedidoId { get; }
        public EstadoPedido NuevoEstado { get; }
        public DateTime Cuando { get; }

        public PedidoChangedEventArgs(int id, EstadoPedido estado, DateTime cuando) => (PedidoId, NuevoEstado, Cuando) = (id, estado, cuando);
    }
}
