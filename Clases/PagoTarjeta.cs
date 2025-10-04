using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{
    public class PagoTarjeta : IPago
    {
        public string Nombre => "Tarjeta de Crédito/Débito";

        public bool Procesar(decimal monto)
        {
            Console.WriteLine($"[TERJETA] Procesando pago ${monto:N2}...");
            
            bool exito = new Random().Next(100) < 95;

            if (exito)
                Console.WriteLine("[TARJETA] ✓ Pago aprobado");
            else
                Console.WriteLine("[TARJETA] x Pago rechazado");

            return exito;
        }
    }
}
