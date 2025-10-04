using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{
    //DECORATOR COMBINADO PARA APLICAR CUPON PORCENTUAL
    public class PagoConCuponPorcentual : PagoDecorator
    {
        private readonly decimal _porcentajeDescuento;

        public override string Nombre => $"{_pagoBase.Nombre} (cupón {_porcentajeDescuento:P})";

        public PagoConCuponPorcentual(IPago pagoBase, decimal porcentajeDescuento) : base(pagoBase)
        {
            _porcentajeDescuento = porcentajeDescuento >= 0 && porcentajeDescuento <= 1
                ? porcentajeDescuento
                : 0;
        }

        public override bool Procesar(decimal monto)
        {
            decimal descuento = monto * _porcentajeDescuento;
            decimal montoConDescuento = monto - descuento;

            Console.WriteLine($"[DECORATOR CUPÓN %] Monto original: ${monto:N2}");
            Console.WriteLine($"[DECORATOR CUPÓN %] Descuento ({_porcentajeDescuento:P}): -${descuento:N2}");
            Console.WriteLine($"[DECORATOR CUPÓN %] Total: ${montoConDescuento:N2}");

            return _pagoBase.Procesar(montoConDescuento);
        }
    }
}
