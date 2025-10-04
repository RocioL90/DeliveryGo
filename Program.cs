using System;
using Clases;
using Interfaces;
using System.Collections.Generic;

namespace DeliveyGo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var pedidos = new PedidoService();
            var notificador = new NotificadorCliente("Cliente Demo");
            var logistica = new SistemaLogistica();
            notificador.SuscribirseA(pedidos);
            logistica.SuscribirseA(pedidos);

            while (true)
            {
                Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1. Crear nuevo pedido");
                Console.WriteLine("2. Listar pedidos");
                Console.WriteLine("3. Cambiar estado de pedido");
                Console.WriteLine("4. Eliminar pedido");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        CrearPedido(pedidos);
                        EsperarYLimpiar();
                        break;
                    case "2":
                        ListarPedidos(pedidos);
                        EsperarYLimpiar();
                        break;
                    case "3":
                        CambiarEstadoPedido(pedidos);
                        EsperarYLimpiar();
                        break;
                    case "4":
                        EliminarPedido(pedidos);
                        EsperarYLimpiar();
                        break;
                    case "0":
                        Console.WriteLine("¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        EsperarYLimpiar();
                        break;
                }
            }
        }

        static void EsperarYLimpiar()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        static void CrearPedido(PedidoService pedidos)
        {
            var pedido = new Pedido();
            Console.Write("Dirección de entrega: ");
            pedido.Direccion = Console.ReadLine();
            Console.Write("Método de pago: ");
            pedido.MetodoPago = Console.ReadLine();
            Console.Write("Subtotal: $");
            decimal subtotal;
            decimal.TryParse(Console.ReadLine(), out subtotal);
            pedido.Subtotal = subtotal;
            pedido.CostoEnvio = 0; 
            pedido.Total = pedido.Subtotal + pedido.CostoEnvio;
            pedidos.AgregarPedido(pedido);
            Console.WriteLine($"Pedido #{pedido.Id} creado exitosamente.");
        }

        static void ListarPedidos(PedidoService pedidos)
        {
            var lista = pedidos.ObtenerTodosPedidos();
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay pedidos registrados.");
                return;
            }
            foreach (var p in lista)
            {
                Console.WriteLine(p);
            }
        }

        static void CambiarEstadoPedido(PedidoService pedidos)
        {
            Console.Write("ID del pedido: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }
            var pedido = pedidos.ObtenerPedido(id);
            if (pedido == null)
            {
                Console.WriteLine("Pedido no encontrado.");
                return;
            }
            Console.WriteLine("Estados disponibles:");
            foreach (var estado in Enum.GetValues(typeof(EstadoPedido)))
            {
                Console.WriteLine($"- {estado}");
            }
            Console.Write("Nuevo estado: ");
            var nuevoEstadoStr = Console.ReadLine();
            EstadoPedido nuevoEstado;
            if (!Enum.TryParse(nuevoEstadoStr, true, out nuevoEstado))
            {
                Console.WriteLine("Estado inválido.");
                return;
            }
            pedidos.CambiarEstado(id, nuevoEstado);
            Console.WriteLine("Estado actualizado.");
        }

        static void EliminarPedido(PedidoService pedidos)
        {
            Console.Write("ID del pedido a eliminar: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }
            var pedido = pedidos.ObtenerPedido(id);
            if (pedido == null)
            {
                Console.WriteLine("Pedido no encontrado.");
                return;
            }
            pedidos.ObtenerTodosPedidos().Remove(pedido);
            Console.WriteLine("Pedido eliminado.");
        }
    }
}
