using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    // Servicio para manejar configuración de envíos
    public class ConfiguracionEnvioService
    {
        private readonly ConfigManager _config;

        public ConfiguracionEnvioService()
        {
            _config = ConfigManager.Instance;
        }

        public void ActualizarUmbralEnvioGratis(decimal nuevoUmbral)
        {
            _config.EnvioGratisDesde = nuevoUmbral;
            Console.WriteLine($"Umbral de envío gratis actualizado a: ${nuevoUmbral:N2}");
        }

        public void ActualizarIVA(decimal nuevoIVA)
        {
            _config.IVA = nuevoIVA;
            Console.WriteLine($"IVA actualizado a: {nuevoIVA:P}");
        }

        public void MostrarConfiguracionActual()
        {
            Console.WriteLine("=== CONFIGURACIÓN ACTUAL ===");
            Console.WriteLine($"Envío gratis desde: ${_config.EnvioGratisDesde:N2}");
            Console.WriteLine($"IVA: {_config.IVA:P}");
        }

        public bool CumpleUmbralEnvioGratis(decimal subtotal)
        {
            return subtotal >= _config.EnvioGratisDesde;
        }

        public decimal CalcularIVA(decimal monto)
        {
            return monto * _config.IVA;
        }
    }
}

