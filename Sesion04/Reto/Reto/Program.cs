using System;
using System.Collections.Generic;
using System.Linq;

namespace Reto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> notas =
                new(StringComparer.OrdinalIgnoreCase);

            while (true)
            {
                Console.WriteLine("\n--- GESTOR DE NOTAS ---");
                Console.WriteLine("1. Registrar aprendiz");
                Console.WriteLine("2. Agregar nota");
                Console.WriteLine("3. Listar aprendices");
                Console.WriteLine("4. Ranking");
                Console.WriteLine("5. Mejor aprendiz y aprobados");
                Console.WriteLine("6. Eliminar aprendiz");
                Console.WriteLine("7. Salir");
                Console.Write("Opcion: ");

                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        Registrar(notas);
                        break;
                    case "2":
                        AgregarNota(notas);
                        break;
                    case "3":
                        Listar(notas);
                        break;
                    case "4":
                        Ranking(notas);
                        break;
                    case "5":
                        MejorAprendiz(notas);
                        break;
                    case "6":
                        Eliminar(notas);
                        break;
                    case "7":
                        Salir();
                        return;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }
            }
        }

        static void Registrar(Dictionary<string, List<double>> notas)
        {
            Console.Write("Nombre del aprendiz: ");
            string nombre = (Console.ReadLine() ?? "").Trim();

            if (nombre == "")
            {
                Console.WriteLine("Escribe un nombre.");
                return;
            }

            if (notas.ContainsKey(nombre))
            {
                Console.WriteLine("El aprendiz ya existe.");
                return;
            }

            notas[nombre] = new List<double>();
            Console.WriteLine("Aprendiz registrado.");
        }

        static void AgregarNota(Dictionary<string, List<double>> notas)
        {
            Console.Write("Nombre del aprendiz: ");
            string nombre = (Console.ReadLine() ?? "").Trim();

            if (!notas.ContainsKey(nombre))
            {
                Console.WriteLine("El aprendiz no existe.");
                return;
            }

            Console.Write("Nota de 0 a 5: ");

            if (double.TryParse(Console.ReadLine(), out double nota)
                && nota >= 0 && nota <= 5)
            {
                notas[nombre].Add(nota);
                Console.WriteLine("Nota agregada.");
            }
            else
            {
                Console.WriteLine("La nota no es valida.");
            }
        }

        static void Listar(Dictionary<string, List<double>> notas)
        {
            foreach (var aprendiz in notas)
            {
                if (aprendiz.Value.Count > 0)
                {
                    double promedio = aprendiz.Value.Average();
                    string juicio = promedio >= 3 ? "A" : "D";

                    Console.WriteLine(
                        $"{aprendiz.Key,-15} {aprendiz.Value.Count} notas · " +
                        $"Promedio {promedio:N1} · Juicio {juicio}");
                }
                else
                {
                    Console.WriteLine($"{aprendiz.Key,-15} Sin notas");
                }
            }
        }

        static void Ranking(Dictionary<string, List<double>> notas)
        {
            var ranking = notas
                .Where(a => a.Value.Count > 0)
                .OrderByDescending(a => a.Value.Average())
                .ToList();

            foreach (var aprendiz in ranking)
            {
                Console.WriteLine(
                    $"{aprendiz.Key,-15} Promedio {aprendiz.Value.Average():N1}");
            }
        }

        static void MejorAprendiz(Dictionary<string, List<double>> notas)
        {
            var aprendices = notas
                .Where(a => a.Value.Count > 0)
                .ToList();

            if (aprendices.Count == 0)
            {
                Console.WriteLine("Todavia no hay notas.");
                return;
            }

            var mejor = aprendices
                .OrderByDescending(a => a.Value.Average())
                .First();

            int aprobados = aprendices
                .Where(a => a.Value.Average() >= 3)
                .Count();

            Console.WriteLine(
                $"Mejor aprendiz: {mejor.Key} - {mejor.Value.Average():N1}");
            Console.WriteLine($"Cantidad de aprobados: {aprobados}");
        }

        static void Eliminar(Dictionary<string, List<double>> notas)
        {
            Console.Write("Nombre del aprendiz: ");
            string nombre = (Console.ReadLine() ?? "").Trim();

            if (notas.Remove(nombre))
            {
                Console.WriteLine("Aprendiz eliminado.");
            }
            else
            {
                Console.WriteLine("El aprendiz no existe.");
            }
        }

        static void Salir()
        {
            Console.WriteLine("Hasta luego.");
        }
    }
}