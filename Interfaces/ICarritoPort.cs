using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Interfaces
{
    
        // Carrito (lo implementa Etapa 1)
        public interface ICarritoPort
        {
            decimal Subtotal(); // suma de(precio* cantidad)
            void Run(ICommand cmd); // ejecuta comando y guarda en historial
            void Undo();
            void Redo();
        }

    
}
