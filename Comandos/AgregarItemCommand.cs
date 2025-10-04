using DeliveyGo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{
    public class AgregarItemCommand : ICommand
    {
        private readonly Carrito _carritoAgregar;
        private readonly string _skuAgregar;
        private readonly string _nombreAgregar;
        private readonly decimal _precioAgregar;
        private readonly int _cantidadAgregar;
        private ItemCarrito _itemAnterior;

        public AgregarItemCommand(Carrito carrito, string sku, string nombre, decimal precio, int cantidad)
        {
            _carritoAgregar = carrito;
            _skuAgregar = sku;
            _nombreAgregar = nombre;
            _precioAgregar = precio;
            _cantidadAgregar = cantidad;
        }

        public void Execute()
        {
            // Guardar estado anterior para Undo
            _itemAnterior = _carritoAgregar._items.ContainsKey(_skuAgregar) ? _carritoAgregar._items[_skuAgregar].Clone() : null;

            if (_carritoAgregar._items.ContainsKey(_skuAgregar))
            {
                _carritoAgregar._items[_skuAgregar].Cantidad += _cantidadAgregar;
            }
            else
            {
                _carritoAgregar._items[_skuAgregar] = new ItemCarrito(_skuAgregar, _nombreAgregar, _precioAgregar, _cantidadAgregar);
            }
        }

        public void Undo()
        {
            if (_itemAnterior == null)
            {
                // No existía antes, lo removemos
                _carritoAgregar._items.Remove(_skuAgregar);
            }
            else
            {
                // Restauramos el estado anterior
                _carritoAgregar._items[_skuAgregar] = _itemAnterior.Clone();
            }
        }
    }
}
