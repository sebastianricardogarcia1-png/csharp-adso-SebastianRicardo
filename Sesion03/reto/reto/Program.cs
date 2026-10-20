
using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string clave = "";

        do
        {
            Console.Write("Ingrese una contraseña: ");
            clave = Console.ReadLine() ?? "";

            int puntos = EvaluarContrasena(clave);

            if (puntos == 6)
            {
                Console.WriteLine("Nivel: Fuerte (" + puntos + "/6)");
            }
            else if (puntos >= 4)
            {
                Console.WriteLine("Nivel: Media (" + puntos + "/6)");
            }
            else
            {
                Console.WriteLine("Nivel: Débil (" + puntos + "/6)");
            }

            Console.WriteLine();

        } while (EvaluarContrasena(clave) != 6);

        Console.WriteLine("Contraseña segura aceptada.");
    }

    static int EvaluarContrasena(string clave)
    {
        bool mayuscula = false;
        bool minuscula = false;
        bool numero = false;
        bool especial = false;

        foreach (char c in clave)
        {
            if (char.IsUpper(c))
            {
                mayuscula = true;
            }
            else if (char.IsLower(c))
            {
                minuscula = true;
            }
            else if (char.IsDigit(c))
            {
                numero = true;
            }
            else if (!char.IsWhiteSpace(c))
            {
                especial = true;
            }
        }

        string[] nombres =
        {
            "Mínimo 8 caracteres",
            "Una mayúscula",
            "Una minúscula",
            "Un número",
            "Un carácter especial",
            "Sin espacios"
        };

        bool[] resultados =
        {
            clave.Length >= 8,
            mayuscula,
            minuscula,
            numero,
            especial,
            !ContieneEspacios(clave)
        };

        int puntos = 0;

        for (int i = 0; i < resultados.Length; i++)
        {
            if (resultados[i])
            {
                Console.WriteLine("✔ " + nombres[i]);
                puntos++;
            }
            else
            {
                Console.WriteLine("✘ " + nombres[i]);
            }
        }

        return puntos;
    }

    static bool ContieneEspacios(string texto)
    {
        foreach (char c in texto)
        {
            if (char.IsWhiteSpace(c))
            {
                return true;
            }
        }

        return false;
    }
}