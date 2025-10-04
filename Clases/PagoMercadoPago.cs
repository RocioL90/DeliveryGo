using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{
    public class PagoMercadoPago : IPago
    {
        public string Nombre => "Mercado Pago";

        public bool Procesar(decimal monto)
        {
            Console.WriteLine($"[MERCADOPAGO] Procesando pago de ${monto:N2}...");

            bool exito = new Random().Next(100) < 98;

            if (exito)
                Console.WriteLine("[MERCADOPAGO] ✓ Pago aprobado");
            else
                Console.WriteLine("[MERCADOPAGO] ✗ Pago rechazado");

            return exito;
        }
    }
}
