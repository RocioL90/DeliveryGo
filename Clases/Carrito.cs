using DeliveyGo.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
namespace Clases
{
    public class Carrito : ICarritoPort
    {       
    
        internal readonly Dictionary<string, ItemCarrito> _items; // internal para que los comandos puedan acceder
        private readonly Stack<ICommand> _historialUndo;
        private readonly Stack<ICommand> _historialRedo;

        public Carrito()
        {
            _items = new Dictionary<string, ItemCarrito>();
            _historialUndo = new Stack<ICommand>();
            _historialRedo = new Stack<ICommand>();
        }

        public decimal Subtotal()
        {
            return _items.Values.Sum(item => item.Subtotal);
        }

        public void Run(ICommand cmd)
        {
            cmd.Execute();
            _historialUndo.Push(cmd);
            _historialRedo.Clear(); // Limpiar redo al ejecutar nuevo comando
        }

        public void Undo()
        {
            if (_historialUndo.Count > 0)
            {
                var comando = _historialUndo.Pop();
                comando.Undo();
                _historialRedo.Push(comando);
            }
        }

        public void Redo()
        {
            if (_historialRedo.Count > 0)
            {
                var comando = _historialRedo.Pop();
                comando.Execute();
                _historialUndo.Push(comando);
            }
        }

        // Métodos adicionales 
        public IEnumerable<ItemCarrito> ObtenerItems()
        {
            return _items.Values.ToList();
        }

        public bool TieneItems()
        {
            return _items.Count > 0;
        }

        public int CantidadItems()
        {
            return _items.Values.Sum(item => item.Cantidad);
        }

        public bool ContieneItem(string sku)
        {
            return _items.ContainsKey(sku);
        }

        public ItemCarrito ObtenerItem(string sku)
        {
            return _items.TryGetValue(sku, out var item) ? item : null;
        }
    }
}
    

