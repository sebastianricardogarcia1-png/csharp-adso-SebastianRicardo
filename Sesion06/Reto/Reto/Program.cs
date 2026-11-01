
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

// Interfaz para los empleados que reciben bonificación
public interface IBonificable
{
    decimal CalcularBono();
}

// Clase abstracta principal
public abstract class Empleado
{
    public string Nombre { get; set; }
    public string Documento { get; set; }

    // Tipo de empleado
    public virtual string Tipo => "Empleado";

    public Empleado(string nombre, string documento)
    {
        Nombre = nombre;
        Documento = documento;
    }

    // Cada empleado calcula su salario de manera diferente
    public abstract decimal CalcularSalario();

    // Mostrar la información del empleado
    public override string ToString()
    {
        return $"Nombre: {Nombre} | Documento: {Documento} | " +
               $"Tipo: {Tipo} | Salario: {CalcularSalario():C0}";
    }
}

// Empleado de planta
public class EmpleadoPlanta : Empleado, IBonificable
{
    public decimal SalarioMensual { get; set; }
    public int AniosAntiguedad { get; set; }

    public override string Tipo => "Empleado de planta";

    public EmpleadoPlanta(string nombre, string documento,
        decimal salarioMensual, int aniosAntiguedad)
        : base(nombre, documento)
    {
        SalarioMensual = salarioMensual;
        AniosAntiguedad = aniosAntiguedad;
    }

    public decimal CalcularBono()
    {
        if (AniosAntiguedad >= 5)
        {
            return SalarioMensual * 0.05m;
        }

        return 0;
    }

    public override decimal CalcularSalario()
    {
        return SalarioMensual + CalcularBono();
    }
}

// Empleado por horas
public class EmpleadoPorHoras : Empleado
{
    public int Horas { get; set; }
    public decimal ValorHora { get; set; }

    public override string Tipo => "Empleado por horas";

    public EmpleadoPorHoras(string nombre, string documento,
        int horas, decimal valorHora)
        : base(nombre, documento)
    {
        Horas = horas;
        ValorHora = valorHora;
    }

    public override decimal CalcularSalario()
    {
        if (Horas > 160)
        {
            decimal horasNormales = 160 * ValorHora;
            decimal horasExtras = (Horas - 160) * ValorHora * 1.5m;

            return horasNormales + horasExtras;
        }

        return Horas * ValorHora;
    }
}

// Contratista
public class Contratista : Empleado
{
    public decimal ValorContrato { get; set; }

    public override string Tipo => "Contratista";

    public Contratista(string nombre, string documento,
        decimal valorContrato)
        : base(nombre, documento)
    {
        ValorContrato = valorContrato;
    }

    public override decimal CalcularSalario()
    {
        return ValorContrato - (ValorContrato * 0.10m);
    }
}

// Programa principal
public class Program
{
    public static void Main(string[] args)
    {
        CultureInfo cultura = CultureInfo.GetCultureInfo("es-CO");

        List<Empleado> nomina = new List<Empleado>
        {
            new EmpleadoPlanta("Ana Gómez", "1001", 3_200_000m, 6),
            new EmpleadoPlanta("Luis Pérez", "1002", 2_800_000m, 2),
            new EmpleadoPorHoras("Marta Ruiz", "1003", 170, 18_000m),
            new EmpleadoPorHoras("Jorge Díaz", "1004", 120, 18_000m),
            new Contratista("Sofía León", "1005", 4_000_000m)
        };

        // Mostrar el pago de cada empleado
        Console.WriteLine("===== NOMINA DE EMPLEADOS =====");

        foreach (Empleado empleado in nomina)
        {
            Console.WriteLine(empleado);
        }

        // Calcular el total de la nómina
        decimal totalNomina = nomina.Sum(e => e.CalcularSalario());

        Console.WriteLine("\n===== TOTAL DE LA NOMINA =====");
        Console.WriteLine(totalNomina.ToString("C0", cultura));

        // Encontrar el empleado con el mayor pago
        Empleado mayorPago = nomina
            .OrderByDescending(e => e.CalcularSalario())
            .First();

        Console.WriteLine("\n===== MAYOR PAGO =====");
        Console.WriteLine(mayorPago);

        // Calcular el total de pago por tipo de empleado
        Console.WriteLine("\n===== TOTAL POR TIPO =====");

        var totalesPorTipo = nomina
            .GroupBy(e => e.Tipo)
            .Select(grupo => new
            {
                Tipo = grupo.Key,
                Total = grupo.Sum(e => e.CalcularSalario())
            });

        foreach (var grupo in totalesPorTipo)
        {
            Console.WriteLine($"{grupo.Tipo}: {grupo.Total.ToString("C0", cultura)}");
        }

        // Calcular el total de bonificaciones
        decimal totalBonos = nomina
            .OfType<IBonificable>()
            .Sum(e => e.CalcularBono());

        Console.WriteLine("\n===== TOTAL DE BONIFICACIONES =====");
        Console.WriteLine(totalBonos.ToString("C0", cultura));
    }
}
