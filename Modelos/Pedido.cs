using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{
    public class Pedido
    {

        private static int _contadorId = 1;

        public int Id { get; private set; }
        public List<ItemPedido> Items { get; private set; }
        public string Direccion { get; set; }
        public string MetodoPago { get; set; }
        public decimal Subtotal { get; set; }
        public decimal CostoEnvio { get; set; }
        public decimal Total { get; set; }
        public EstadoPedido Estado { get; set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime UltimaActualizacion { get; set; }

        public Pedido()
        {
            Id = _contadorId++;
            Items = new List<ItemPedido>();
            Estado = EstadoPedido.Recibido;
            FechaCreacion = DateTime.Now;
            UltimaActualizacion = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Pedido #{Id} - {Estado} - Total: ${Total:N2}";
        }
    }


}

