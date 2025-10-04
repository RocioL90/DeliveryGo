using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{
    public class PagoConIVA : PagoDecorator
    {
        private readonly decimal _tasaIVA;

        public override string Nombre => $"{_pagoBase.Nombre} (con IVA)";

        public PagoConIVA(IPago pagoBase, decimal tasaIVA) : base(pagoBase)
        {
            _tasaIVA = tasaIVA;
        }

        public PagoConIVA(IPago pagoBase) : base(pagoBase)
        {
            _tasaIVA = ConfigManager.Instance.IVA;
        }

        public override bool Procesar(decimal monto)
        {
            decimal iva = monto * _tasaIVA;
            decimal montoConIVA = monto + iva;

            Console.WriteLine($"[DECORATOR IVA] Monto original: ${monto:N2}");
            Console.WriteLine($"[DECORATOR IVA] IVA ({_tasaIVA:P}): ${iva:N2}");
            Console.WriteLine($"[DECORATOR IVA] Total con IVA: ${montoConIVA:N2}");

            return _pagoBase.Procesar(montoConIVA);
        }
    }
}
