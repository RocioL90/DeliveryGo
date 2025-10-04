using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{
        public class EnvioPorcentual : IEnvioStrategy
        {
            private readonly decimal _porcentaje;
            private readonly decimal _minimo;
            private readonly decimal _maximo;

            public string Nombre { get; }

            public EnvioPorcentual(string nombre, decimal porcentaje, decimal minimo = 2000m, decimal maximo = 15000m)
            {
                Nombre = nombre;
                _porcentaje = porcentaje;
                _minimo = minimo;
                _maximo = maximo;
            }

            public decimal Calcular(decimal subtotal)
            {
                var config = ConfigManager.Instance;

                // Si supera el umbral de envío gratis, no cobra
                if (subtotal >= config.EnvioGratisDesde)
                    return 0m;

                // Calcular como porcentaje del subtotal
                var costoCalculado = subtotal * _porcentaje;

                // Aplicar límites mínimo y máximo
                return Math.Max(_minimo, Math.Min(_maximo, costoCalculado));
            }
        }
    
}
