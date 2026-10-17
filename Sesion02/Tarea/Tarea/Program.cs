using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();
            int secreto = random.Next(1, 101);
            int intentos = 0;
            bool acerto = false;

            while (intentos < 7)
            {
                Console.Write("Adivina el numero del 1 al 100: ");


                if (!int.TryParse(Console.ReadLine(), out int numero))
                {
                    Console.WriteLine("Ingresa un numero valido.");
                    continue;
                }

                intentos++;

                if (numero == secreto)
                {
                    Console.WriteLine("¡Correcto! Adivinaste en " + intentos + " intentos.");
                    acerto = true;
                    break;
                }
                else if (numero < secreto)
                {
                    Console.WriteLine("El numero secreto es mayor.");
                }
                else
                {
                    Console.WriteLine("El numero secreto es menor.");
                }
            }

            if (!acerto)
            {
                Console.WriteLine("Se acabaron los intentos. El numero era: " + secreto);
            }

        }
    }
}
