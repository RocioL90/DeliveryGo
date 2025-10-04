using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IEnvioStrategy
    {
        // Strategy de Envío (la implementa Etapa 2)
        decimal Calcular(decimal subtotal);
        string Nombre { get; }
    }
}
