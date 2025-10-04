using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{
    public abstract class PagoDecorator : IPago
    {
        protected IPago _pagoBase;

        public abstract string Nombre { get; }

        protected PagoDecorator(IPago pagoBase)
        {
            _pagoBase = pagoBase;
        }

        public virtual bool Procesar(decimal monto)
        {
            return _pagoBase.Procesar(monto);
        }
    }
}
