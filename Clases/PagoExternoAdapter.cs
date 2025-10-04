using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Clases
{
    //ADAPTER PARA INTEGRAR EL SDK EXTERNO CON LA INTERFAZ IPAGO
    public class PagoExternoAdapter : IPago
    {
        private readonly PagoExternoSDK _sdkExterno;
        private readonly string _metodoSDK;

        public string Nombre {  get; }

        public PagoExternoAdapter(string nombre, string metodoSDK)
        {
            Nombre = nombre;
            _metodoSDK = metodoSDK;
            _sdkExterno = new PagoExternoSDK();
        }

        public bool Procesar(decimal monto)
        {
            Console.WriteLine($"[ADAPTER] Adaptando llamada a SDK externo...");
            
            //Convierte en decimal a double
            double montoDouble = (double)monto;

            //Llama al SDK externo
            int codigoRespuesta = _sdkExterno.RealizarTransaccion(montoDouble, _metodoSDK);

            //Adaptar la respuesta del SDK al formato bool
            bool exito = codigoRespuesta == 200;

            if (exito)
                Console.WriteLine($"[ADAPTER] {Nombre} procesado exitosamente");
            else
                Console.WriteLine($"[ADAPTER] {Nombre} fallo (codigo {codigoRespuesta})");

            return exito;
               
        }
    }
}
