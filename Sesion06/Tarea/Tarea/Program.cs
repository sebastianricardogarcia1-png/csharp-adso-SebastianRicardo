
using System;
using System.Linq;

// Interfaz para los metodos de pago
public interface IMetodoPago
{
    string Nombre { get; }

    decimal CalcularComision(decimal monto);

    bool Validar(decimal monto);
}

// Interfaz para los metodos que permiten reembolsos
public interface IReembolsable
{
    void Reembolsar(decimal monto);
}

// Pago en efectivo
public class PagoEfectivo : IMetodoPago
{
    public string Nombre => "Efectivo";

    public decimal CalcularComision(decimal monto)
    {
        return 0;
    }

    public bool Validar(decimal monto)
    {
        return monto > 0;
    }
}

// Pago con tarjeta
public class PagoTarjeta : IMetodoPago, IReembolsable
{
    public string NumeroTarjeta { get; set; }

    public string Nombre => "Tarjeta";

    public PagoTarjeta(string numeroTarjeta)
    {
        NumeroTarjeta = numeroTarjeta;
    }

    public decimal CalcularComision(decimal monto)
    {
        return monto * 0.03m;
    }

    public bool Validar(decimal monto)
    {
        return monto > 0 &&
               NumeroTarjeta.Length == 16 &&
               NumeroTarjeta.All(char.IsDigit);
    }

    public void Reembolsar(decimal monto)
    {
        Console.WriteLine($"Reembolso de tarjeta realizado: {monto:C0}");
    }
}

// Pago con billetera digital
public class PagoBilletera : IMetodoPago, IReembolsable
{
    public string Nombre => "Billetera";

    public decimal CalcularComision(decimal monto)
    {
        return monto * 0.01m;
    }

    public bool Validar(decimal monto)
    {
        return monto > 0 && monto <= 2_000_000m;
    }

    public void Reembolsar(decimal monto)
    {
        Console.WriteLine($"Reembolso de billetera realizado: {monto:C0}");
    }
}

// Procesador de pagos
public class ProcesadorPagos
{
    public void Cobrar(IMetodoPago metodo, decimal monto)
    {
        Console.WriteLine($"\n===== PAGO CON {metodo.Nombre.ToUpper()} =====");

        if (!metodo.Validar(monto))
        {
            Console.WriteLine("El pago no es valido.");
            return;
        }

        decimal comision = metodo.CalcularComision(monto);
        decimal total = monto + comision;

        Console.WriteLine($"Monto: {monto:C0}");
        Console.WriteLine($"Comision: {comision:C0}");
        Console.WriteLine($"Total a pagar: {total:C0}");
        Console.WriteLine("Pago realizado correctamente.");
    }

    public void Devolver(IMetodoPago metodo, decimal monto)
    {
        Console.WriteLine($"\n===== REEMBOLSO =====");

        if (metodo is IReembolsable reembolsable)
        {
            reembolsable.Reembolsar(monto);
        }
        else
        {
            Console.WriteLine("Este metodo de pago no permite reembolsos.");
        }
    }
}

// Programa principal
public class Program
{
    public static void Main(string[] args)
    {
        ProcesadorPagos procesador = new ProcesadorPagos();

        // Crear los metodos de pago
        IMetodoPago efectivo = new PagoEfectivo();

        IMetodoPago tarjeta = new PagoTarjeta("1234567890123456");

        IMetodoPago billetera = new PagoBilletera();

        // Realizar los cobros
        procesador.Cobrar(efectivo, 500_000m);

        procesador.Cobrar(tarjeta, 1_000_000m);

        procesador.Cobrar(billetera, 1_500_000m);

        // Intentar realizar un pago que supera el limite
        procesador.Cobrar(billetera, 2_500_000m);

        // Realizar los reembolsos
        procesador.Devolver(efectivo, 100_000m);

        procesador.Devolver(tarjeta, 200_000m);

        procesador.Devolver(billetera, 300_000m);
    }
}
