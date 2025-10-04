using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{
    //FACTORY DE PAGOS
    public class PagoFactory
    {
        public static IPago CrearPago(string tipoPago)
        {
            switch (tipoPago.ToLower())
            {
                case "tarjeta":
                case "credito":
                case "debito":
                    return new PagoTarjeta();

                case "mp":
                case "mercadopago":
                    return new PagoMercadoPago();

                case "transferencia":
                case "transf":
                    return new PagoTransferencia();

                case "adapter":
                case "externo":
                    return new PagoExternoAdapter("Pago Externo", "CREDIT_CARD");

                default:
                    return new PagoTarjeta(); // Por defecto
            }
        }

        public static IPago CrearPagoConDecoradores(string tipoPago, bool aplicarIVA, decimal? cupon = null)
        {
            IPago pago = CrearPago(tipoPago);

            // Aplicar cupón primero (si existe)
            if (cupon.HasValue && cupon.Value > 0)
            {
                pago = new PagoConCupon(pago, cupon.Value);
            }

            // Aplicar IVA después (si corresponde)
            if (aplicarIVA)
            {
                pago = new PagoConIVA(pago);
            }

            return pago;
        }

        public static IPago CrearPagoConCuponPorcentual(string tipoPago, bool aplicarIVA, decimal? porcentajeDescuento = null)
        {
            IPago pago = CrearPago(tipoPago);

            // Aplicar cupón porcentual primero (si existe)
            if (porcentajeDescuento.HasValue && porcentajeDescuento.Value > 0)
            {
                pago = new PagoConCuponPorcentual(pago, porcentajeDescuento.Value);
            }

            // Aplicar IVA después
            if (aplicarIVA)
            {
                pago = new PagoConIVA(pago);
            }

            return pago;
        }
    }
}
    


