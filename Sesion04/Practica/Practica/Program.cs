using System.ComponentModel;

Console.WriteLine("Hello, World!");


//Crear una lista

List<string> compras = ["Arroz", "Leche", "frijol", "Leche"];

Console.WriteLine($"Tienes antes de agregar  {compras.Count} elementos");

compras.Add("café"); //permite agregar a una lista

Console.WriteLine($"Tienes despues de agregar de agregar  {compras.Count} elementos");

//compras.Remove("Leche"); //permite eli{minar un elemento

Console.WriteLine(string.Join(", ", compras));

compras.Sort(); //ordena la lista

Console.WriteLine(string.Join(", ", compras));


Console.WriteLine("======================");
//crear un diccionario

Dictionary<string, string> agenda = new(StringComparer.OrdinalIgnoreCase);

agenda["Anna"] = "3001234567";
agenda["Luis"] = "3154444444";


if (agenda.TryGetValue("Ana", out string? telefono))
{
    Console.WriteLine($"Ana: {telefono}");

}

foreach (var (nombre, tel) in agenda)
{
    Console.WriteLine($"{nombre}: {tel}");
}

Console.WriteLine("=======================");

//diccionario con listas adentro 

Dictionary<string, List<double>> notas = new(StringComparer.OrdinalIgnoreCase);
notas["Miguel"] = [];
notas["Miguel"].Add(4.5);
notas["Miguel"].Add(3.8);
notas["Miguel"].Add(1);

foreach (var (nombre, nota) in notas)
{
    Console.WriteLine($"{nombre}: {string.Join(" - ", nota)}");
}


Console.WriteLine("=====================");

List<int> numeros = [10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];
