using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Usamos punto y coma para mostrar la moneda al estilo colombiano
            CultureInfo cultura = new CultureInfo("es-CO");

            // Pedimos los datos de la cuenta
            Console.Write("Total de la cuenta: ");
            bool okTotal = decimal.TryParse(Console.ReadLine(), out decimal total);

            Console.Write("Porcentaje de propina (10, 15 o 20): ");
            bool okPct = decimal.TryParse(Console.ReadLine(), out decimal porcentaje);

            Console.Write("Número de personas: ");
            bool okPersonas = int.TryParse(Console.ReadLine(), out int personas);

            // Revisamos si los datos se escribieron correctamente
            if (!okTotal || !okPct || !okPersonas)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Por favor, ingresa datos válidos.");
                Console.ResetColor();
                return;
            }

            // Revisamos que los valores tengan sentido
            if (total <= 0 || porcentaje < 0 || personas <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La cuenta y las personas deben ser mayores que cero, y la propina no puede ser negativa.");
                Console.ResetColor();
                return;
            }

            // Calculamos la propina y el total de la cuenta
            decimal propina = total * porcentaje / 100m;
            decimal totalConPropina = total + propina;
            decimal pagoPersona = totalConPropina / personas;

            // Mostramos los resultados en color verde
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"\nPropina: {propina.ToString("C0", cultura)}");
            Console.WriteLine($"Total: {totalConPropina.ToString("C0", cultura)}");
            Console.WriteLine($"Cada persona paga: {pagoPersona.ToString("C0", cultura)}");

            // Restauramos el color normal de la consola
            Console.ResetColor();
        }
    }
}
