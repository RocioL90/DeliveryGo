using DeliveyGo.Clases;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Interfaces.IPago;

namespace Clases
{
    public partial class CheckoutFacade
    {
        private readonly ICarritoPort _carrito;
        private IEnvioStrategy _envio;
        private readonly PedidoService _pedidos;
        private readonly ConfiguracionEnvioService _configEnvio;

        public CheckoutFacade(ICarritoPort carrito, IEnvioStrategy envio, PedidoService pedidos)
        {
            _carrito = carrito;
            _envio = envio ?? new EnvioStandard(); // Estrategia por defecto
            _pedidos = pedidos;
            _configEnvio = new ConfiguracionEnvioService();
        }

        // === MÉTODOS DE CARRITO (Etapa 1) ===
        public void AgregarItem(string sku, string nombre, decimal precio, int cantidad)
        {
            var comando = new AgregarItemCommand(_carrito as Carrito, sku, nombre, precio, cantidad);
            _carrito.Run(comando);
        }

        public void CambiarCantidad(string sku, int cantidad)
        {
            var comando = new CambiarCantidadCommand(_carrito as Carrito, sku, cantidad);
            _carrito.Run(comando);
        }

        public void QuitarItem(string sku)
        {
            var comando = new QuitarItemCommand(_carrito as Carrito, sku);
            _carrito.Run(comando);
        }

        // === MÉTODOS DE ENVÍO (Etapa 2) ===
        public void ElegirEnvio(IEnvioStrategy estrategia)
        {
            _envio = estrategia ?? throw new ArgumentNullException(nameof(estrategia));
            Console.WriteLine($"Estrategia de envío cambiada a: {_envio.Nombre}");
        }

        public void ElegirEnvio(string tipoEnvio)
        {
            _envio = EnvioStrategyFactory.CrearEstrategia(tipoEnvio);
            Console.WriteLine($"Estrategia de envío cambiada a: {_envio.Nombre}");
        }

        public decimal CalcularTotal()
        {
            var subtotal = _carrito.Subtotal();
            var costoEnvio = _envio.Calcular(subtotal);
            return subtotal + costoEnvio;
        }

        public decimal ObtenerCostoEnvio()
        {
            return _envio.Calcular(_carrito.Subtotal());
        }

        public string ObtenerNombreEnvio()
        {
            return _envio.Nombre;
        }

        public bool TieneEnvioGratis()
        {
            return ObtenerCostoEnvio() == 0m;
        }

        // === MÉTODOS DE CONFIGURACIÓN ===
        public void ActualizarUmbralEnvioGratis(decimal nuevoUmbral)
        {
            _configEnvio.ActualizarUmbralEnvioGratis(nuevoUmbral);
        }

        public bool CumpleUmbralEnvioGratis()
        {
            return _configEnvio.CumpleUmbralEnvioGratis(_carrito.Subtotal());
        }

        public void MostrarConfiguracion()
        {
            _configEnvio.MostrarConfiguracionActual();
        }

        // === MÉTODOS QUE SE IMPLEMENTARÁN EN ETAPA 3 ===
        public bool Pagar(string tipoPago, bool aplicarIVA, decimal? cupon = null)
        {
            /* Factory/Adapter/Decorator - Etapa 3 */
            return false;
        }

        public Pedido ConfirmarPedido(string direccion, string tipoPago)
        {
            /* Builder + Observer - Etapa 3 */
            return new Pedido();
        }

        // === MÉTODOS DE CONVENIENCIA ===
        public void DeshacerUltimaOperacion() => _carrito.Undo();
        public void RehacerOperacion() => _carrito.Redo();
        public decimal ObtenerSubtotal() => _carrito.Subtotal();

        // Resumen completo del checkout
        public void MostrarResumen()
        {
            var carrito = _carrito as Carrito;
            if (carrito == null || !carrito.TieneItems())
            {
                Console.WriteLine("El carrito está vacío.");
                return;
            }

            Console.WriteLine("\n=== RESUMEN DEL PEDIDO ===");

            foreach (var item in carrito.ObtenerItems())
            {
                Console.WriteLine($"• {item}");
            }

            Console.WriteLine($"\nSubtotal: ${ObtenerSubtotal():N2}");
            Console.WriteLine($"Envío ({ObtenerNombreEnvio()}): ${ObtenerCostoEnvio():N2}");

            if (TieneEnvioGratis())
            {
                Console.WriteLine("  ¡Envío GRATIS! 🎉");
            }

            Console.WriteLine($"TOTAL: ${CalcularTotal():N2}");
            Console.WriteLine($"Items: {carrito.CantidadItems()}");
        }

        // Obtener estrategias disponibles
        public IEnvioStrategy[] ObtenerEstrategiasDisponibles()
        {
            return EnvioStrategyFactory.ObtenerEstrategiasDisponibles();
        }
    }
        
}
        

