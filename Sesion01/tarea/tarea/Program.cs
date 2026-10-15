using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Pedimos la cantidad de segundos
            //Console.Write("Ingresa la cantidad de segundos: ");
            //bool okSegundos = int.TryParse(Console.ReadLine(), out int segundos);

            // Revisamos que el dato sea correcto
            //if (!okSegundos || segundos < 0)
            //{
            //Console.WriteLine("Por favor, ingresa una cantidad válida.");
            //return;
            //}

            // Calculamos las horas, los minutos y los segundos
            //int horas = segundos / 3600;
            //int minutos = (segundos % 3600) / 60;
            //int segundosRestantes = segundos % 60;

            // Mostramos el resultado
            //Console.WriteLine($"{horas} h {minutos} min {segundosRestantes} s");



            // Pedimos la temperatura en grados Celsius
            //Console.Write("Ingresa la temperatura en Celsius: ");
            //bool okCelsius = double.TryParse(Console.ReadLine(), out double celsius);

            // Revisamos que la temperatura sea válida
            //if (!okCelsius)
            //{
            //Console.WriteLine("Por favor, ingresa una temperatura válida.");
            //return;
            //}

            // Convertimos la temperatura a Fahrenheit
            //double fahrenheit = celsius * 9 / 5 + 32;

            // Mostramos el resultado
            //Console.WriteLine($"Temperatura en Fahrenheit: {fahrenheit:F1} °F");



            // Pedimos las tres notas
            Console.Write("Ingresa la primera nota: ");
            bool okNota1 = double.TryParse(Console.ReadLine(), out double nota1);

            Console.Write("Ingresa la segunda nota: ");
            bool okNota2 = double.TryParse(Console.ReadLine(), out double nota2);

            Console.Write("Ingresa la tercera nota: ");
            bool okNota3 = double.TryParse(Console.ReadLine(), out double nota3);

            // Revisamos que las notas sean válidas
            if (!okNota1 || !okNota2 || !okNota3)
            {
                Console.WriteLine("Por favor, ingresa notas válidas.");
                return;
            }

            // Revisamos que las notas estén entre 0 y 5
            if (nota1 < 0 || nota1 > 5 ||
                nota2 < 0 || nota2 > 5 ||
                nota3 < 0 || nota3 > 5)
            {
                Console.WriteLine("Las notas deben estar entre 0 y 5.");
                return;
            }

            // Calculamos el promedio
            double promedio = (nota1 + nota2 + nota3) / 3;

            // Mostramos el promedio con un decimal
            Console.WriteLine($"El promedio es: {promedio:F1}");
        }
    }
}
