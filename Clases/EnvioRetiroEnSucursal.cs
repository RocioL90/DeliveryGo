using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{   
        public class EnvioRetiroEnSucursal : IEnvioStrategy
        {
            public string Nombre => "Retiro en Sucursal";

            public decimal Calcular(decimal subtotal)
            {
                // Retiro en sucursal siempre es gratis
                return 0m;
            }
        }
    
}
