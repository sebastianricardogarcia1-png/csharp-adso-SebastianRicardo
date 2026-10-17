using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal saldo = 500000;
            int pinCorrecto = 1234;
            int transacciones = 0;
            bool acceso = false;

            // Verificar el PIN con maximo 3 intentos
            for (int i = 1; i <= 3; i++)
            {
                Console.Write("Ingresa tu PIN: ");
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int pin) && pin == pinCorrecto)
                {
                    acceso = true;
                    break;
                }

                Console.WriteLine("PIN incorrecto.");
            }

            if (!acceso)
            {
                Console.WriteLine("Tarjeta bloqueada");
                return;
            }

            int opcion;

            do
            {
                Console.WriteLine("\n--- CAJERO AUTOMATICO ---");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar");
                Console.WriteLine("3. Retirar");
                Console.WriteLine("4. Salir");
                Console.Write("Elige una opcion: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = 0;
                }

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Tu saldo es: $" + saldo);
                        break;

                    case 2:
                        Console.Write("Cuanto deseas depositar: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal deposito)
                            && deposito > 0)
                        {
                            saldo += deposito;
                            transacciones++;

                            Console.WriteLine("Deposito realizado.");
                            Console.WriteLine("Nuevo saldo: $" + saldo);
                        }
                        else
                        {
                            Console.WriteLine("Ingresa un valor valido mayor que cero.");
                        }
                        break;

                    case 3:
                        Console.Write("Cuanto deseas retirar: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal retiro)
                            && retiro > 0)
                        {
                            if (retiro % 10000 == 0 && retiro <= saldo)
                            {
                                saldo -= retiro;
                                transacciones++;

                                Console.WriteLine("Retiro realizado.");
                                Console.WriteLine("Nuevo saldo: $" + saldo);
                            }
                            else
                            {
                                Console.WriteLine("El retiro debe ser multiplo de $10.000 y no superar tu saldo.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ingresa un valor valido mayor que cero.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Gracias por utilizar el cajero.");
                        Console.WriteLine("Transacciones realizadas: " + transacciones);
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }

            } while (opcion != 4);
        }
    }
}
