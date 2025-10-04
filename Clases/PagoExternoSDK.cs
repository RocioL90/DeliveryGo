using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    //ADAPTER - SDK EXTERNO DE PAGO
    public class PagoExternoSDK
    {
        public int RealizarTransaccion(double importe, string metodo)
        {
            Console.WriteLine($"[SDK EXTERNO] Procesando {metodo}: ${importe}...");

            return new Random().Next(100) < 90 ? 200 : 400;
        }
    }
}
