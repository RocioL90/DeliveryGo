using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{    
        // Estrategia especial para envíos a zonas alejadas
        public class EnvioZonaAlejada : IEnvioStrategy
        {
            private readonly decimal _recargo;

            public string Nombre => $"Envío Zona Alejada (+${_recargo:N0} recargo)";

            public EnvioZonaAlejada(decimal recargo = 10000m)
            {
                _recargo = recargo;
            }

            public decimal Calcular(decimal subtotal)
            {
                var config = ConfigManager.Instance;
                var envioBase = new EnvioStandard();
                var costoBase = envioBase.Calcular(subtotal);

                // Si el envío base es gratis, solo cobra el recargo
                if (costoBase == 0)
                    return _recargo * 0.5m; // Recargo reducido si supera umbral

                // Suma el recargo al costo base
                return costoBase + _recargo;
            }
        }
    
}
