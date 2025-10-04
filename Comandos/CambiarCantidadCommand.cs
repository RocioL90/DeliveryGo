using DeliveyGo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{
    public class CambiarCantidadCommand : ICommand
    {
        private readonly Carrito _carritoCambiar;
        private readonly string _skuCambiar;
        private readonly int _nuevaCantidadCambiar;
        private ItemCarrito _itemAnteriorCambiar;

        public CambiarCantidadCommand(Carrito carrito, string sku, int nuevaCantidad)
        {
            _carritoCambiar = carrito;
            _skuCambiar = sku;
            _nuevaCantidadCambiar = nuevaCantidad;
        }

        public void Execute()
        {
            if (!_carritoCambiar._items.ContainsKey(_skuCambiar))
                throw new InvalidOperationException($"El item con SKU {_skuCambiar} no existe en el carrito");

            // Guardar estado anterior
            _itemAnteriorCambiar = _carritoCambiar._items[_skuCambiar].Clone();

            if (_nuevaCantidadCambiar <= 0)
            {
                _carritoCambiar._items.Remove(_skuCambiar);
            }
            else
            {
                _carritoCambiar._items[_skuCambiar].Cantidad = _nuevaCantidadCambiar;
            }
        }

        public void Undo()
        {
            if (_itemAnteriorCambiar == null)
                return;

            _carritoCambiar._items[_skuCambiar] = _itemAnteriorCambiar.Clone();
        }
    }
    
    
        
}
