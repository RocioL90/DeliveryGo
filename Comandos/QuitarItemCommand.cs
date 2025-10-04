using DeliveyGo.Clases;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class QuitarItemCommand : ICommand
    {
        private readonly Carrito _carritoQuitar;
        private readonly string _skuQuitar;
        private ItemCarrito _itemAnteriorQuitar;

        public QuitarItemCommand(Carrito carrito, string sku)
        {
            _carritoQuitar = carrito;
            _skuQuitar = sku;
        }

        public void Execute()
        {
            if (_carritoQuitar._items.ContainsKey(_skuQuitar))
            {
                _itemAnteriorQuitar = _carritoQuitar._items[_skuQuitar].Clone();
                _carritoQuitar._items.Remove(_skuQuitar);
            }
        }

        public void Undo()
        {
            if (_itemAnteriorQuitar != null)
            {
                _carritoQuitar._items[_skuQuitar] = _itemAnteriorQuitar.Clone();
            }
        }
    }
    
    
}
