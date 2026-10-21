
using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== GENERADOR DE USUARIOS ===");

        Console.Write("Ingrese el nombre completo: ");
        string nombre = Console.ReadLine() ?? "";

        Console.Write("Ingrese el documento: ");
        string documento = Console.ReadLine() ?? "";

        string usuario = GenerarUsuario(nombre, documento);

        Console.WriteLine($"Usuario generado: {usuario}");

        Console.WriteLine("\n=== ANALIZADOR DE FRASES ===");

        Console.Write("Ingrese una frase: ");
        string frase = Console.ReadLine() ?? "";

        int cantidad = ContarPalabras(frase);
        string fraseInvertida = InvertirPalabras(frase);

        Console.WriteLine($"Cantidad de palabras: {cantidad}");
        Console.WriteLine($"Frase en orden inverso: {fraseInvertida}");
    }

    static string GenerarUsuario(string nombreCompleto, string documento)
    {
        nombreCompleto = QuitarTildes(nombreCompleto.ToLower().Trim());

        string[] partes = nombreCompleto.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        if (partes.Length < 2 || documento.Length < 2)
        {
            return "Datos no validos";
        }

        string primerNombre = partes[0];
        string primerApellido = partes.Length == 4
            ? partes[2]
            : partes[1];

        string ultimosDigitos = documento.Substring(documento.Length - 2);

        return primerNombre[0] + primerApellido + ultimosDigitos;
    }

    static string QuitarTildes(string texto)
    {
        return texto
            .Replace("á", "a")
            .Replace("é", "e")
            .Replace("í", "i")
            .Replace("ó", "o")
            .Replace("ú", "u")
            .Replace("ü", "u")
            .Replace("ñ", "n");
    }

    static int ContarPalabras(string frase)
    {
        string[] palabras = frase.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        return palabras.Length;
    }

    static string InvertirPalabras(string frase)
    {
        string[] palabras = frase.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        StringBuilder resultado = new StringBuilder();

        for (int i = palabras.Length - 1; i >= 0; i--)
        {
            resultado.Append(palabras[i]);

            if (i > 0)
            {
                resultado.Append(" ");
            }
        }

        return resultado.ToString();
    }
}
