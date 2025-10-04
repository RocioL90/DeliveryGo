using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{    
        public class EnvioExpress : IEnvioStrategy
        {
            public string Nombre => "Envío Express (24hs)";

            public decimal Calcular(decimal subtotal)
            {
                var config = ConfigManager.Instance;

                // Express tiene descuento si supera el umbral, pero no es gratis
                if (subtotal >= config.EnvioGratisDesde)
                    return 8000m; // Precio con descuento

                // Precio normal para express
                return 12000m;
            }
        }
    
}
