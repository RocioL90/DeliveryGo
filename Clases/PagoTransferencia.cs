using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{
    public class PagoTransferencia : IPago
    {
        public string Nombre => "Transferencia Bancaria";

        public bool Procesar(decimal monto)
        {
            Console.WriteLine($"[TRANSFERENCIA] Generando datos para transferencia de ${monto:N2}...");
            Console.WriteLine($"[TRANSFERENCIA] CBU: 123456789");
            Console.WriteLine($"[TRANSFERENCIA] Pendiente de confirmacion");

            return true;
        }
    }
}
