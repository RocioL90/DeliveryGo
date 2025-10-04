using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{
    public class EnvioStrategyFactory
    {
        public static IEnvioStrategy CrearEstrategia(string tipoEnvio)
        {
            switch (tipoEnvio.ToLower())
            {
                case "standard":
                    return new EnvioStandard();
                case "express":
                    return new EnvioExpress();
                case "retiro":
                case "sucursal":
                    return new EnvioRetiroEnSucursal();
                case "porcentual":
                    return new EnvioPorcentual("Envío Porcentual", 0.05m); // 5%
                case "zona_alejada":
                case "alejada":
                    return new EnvioZonaAlejada();
                default:
                    return new EnvioStandard(); // Por defecto
            }
        }

        public static IEnvioStrategy[] ObtenerEstrategiasDisponibles()
            {
                return new IEnvioStrategy[]
                {
                new EnvioRetiroEnSucursal(),
                new EnvioStandard(),
                new EnvioExpress(),
                new EnvioPorcentual("Envío Flexible", 0.04m, 3000m, 10000m),
                new EnvioZonaAlejada()
                };
            }
        
    }
}
