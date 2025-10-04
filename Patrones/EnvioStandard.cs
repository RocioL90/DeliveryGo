using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{   
        public class EnvioStandard : IEnvioStrategy
        {
            public string Nombre => "Envío Standard";

            public decimal Calcular(decimal subtotal)
            {
                var config = ConfigManager.Instance;

                // Si supera el umbral de envío gratis, no cobra
                if (subtotal >= config.EnvioGratisDesde)
                    return 0m;

                // Costo fijo para envío standard
                return 5000m;
            }
        }
    
}
