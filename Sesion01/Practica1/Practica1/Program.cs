using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("¿Cómo te llamas? ");
            string entrada = Console.ReadLine() ?? "";
            string nombre = string.IsNullOrWhiteSpace(entrada) ? "Invitado" : entrada;
            Console.Write("¿De qué ciudad eres? ");
            entrada = Console.ReadLine() ?? "";
            string ciudad = string.IsNullOrWhiteSpace(entrada) ? "Ciudad" : entrada;
            Console.WriteLine($"Hola, {nombre} de {ciudad}. ¡Bienvenido a C#!");
        }
    }
}
