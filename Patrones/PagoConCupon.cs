using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{
    //DECORATOR PARA APLICAR CUPON DE DESCUENTO
    public class PagoConCupon : PagoDecorator
    {
        private readonly decimal _descuento;

        public override string Nombre => $"{_pagoBase.Nombre} (con cupón)";

        public PagoConCupon(IPago pagoBase, decimal descuento) : base(pagoBase)
        {
            _descuento = descuento > 0 ? descuento : 0;
        }

        public override bool Procesar(decimal monto)
        {
            decimal montoConDescuento = monto - _descuento;

            // El descuento no puede hacer que el monto sea negativo
            if (montoConDescuento < 0)
                montoConDescuento = 0;

            Console.WriteLine($"[DECORATOR CUPÓN] Monto original: ${monto:N2}");
            Console.WriteLine($"[DECORATOR CUPÓN] Descuento: -${_descuento:N2}");
            Console.WriteLine($"[DECORATOR CUPÓN] Total con descuento: ${montoConDescuento:N2}");

            return _pagoBase.Procesar(montoConDescuento);
        }
    }
}
