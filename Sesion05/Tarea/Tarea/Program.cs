
using System;

namespace Tarea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CuentaBancaria cuenta1 = new CuentaBancaria(
                "Sebastian", "1001", 500000
            );

            CuentaBancaria cuenta2 = new CuentaBancaria(
                "Daniel", "1002"
            );

            Console.WriteLine("===== CUENTAS BANCARIAS =====");

            Console.WriteLine($"Titular: {cuenta1.Titular}");
            Console.WriteLine($"Numero: {cuenta1.Numero}");
            Console.WriteLine($"Saldo inicial: {cuenta1.Saldo:C0}");

            Console.WriteLine();

            Console.WriteLine($"Titular: {cuenta2.Titular}");
            Console.WriteLine($"Numero: {cuenta2.Numero}");
            Console.WriteLine($"Saldo inicial: {cuenta2.Saldo:C0}");

            Console.WriteLine("\n===== DEPOSITO =====");

            if (cuenta1.Depositar(100000))
            {
                Console.WriteLine("Deposito realizado correctamente.");
            }
            else
            {
                Console.WriteLine("No se pudo realizar el deposito.");
            }

            Console.WriteLine($"Saldo actual: {cuenta1.Saldo:C0}");

            Console.WriteLine("\n===== RETIRO =====");

            if (cuenta1.Retirar(1000000))
            {
                Console.WriteLine("Retiro realizado correctamente.");
            }
            else
            {
                Console.WriteLine("Retiro rechazado: saldo insuficiente.");
            }

            Console.WriteLine("\n===== TRANSFERENCIA =====");

            if (cuenta1.Transferir(cuenta2, 200000))
            {
                Console.WriteLine("Transferencia realizada correctamente.");
            }
            else
            {
                Console.WriteLine("No se pudo realizar la transferencia.");
            }

            Console.WriteLine("\n===== SALDOS FINALES =====");

            Console.WriteLine(
                $"{cuenta1.Titular}: {cuenta1.Saldo:C0}"
            );

            Console.WriteLine(
                $"{cuenta2.Titular}: {cuenta2.Saldo:C0}"
            );
        }
    }
}
