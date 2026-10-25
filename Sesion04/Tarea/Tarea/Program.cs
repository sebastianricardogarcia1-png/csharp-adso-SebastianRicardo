
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

CultureInfo cultura = CultureInfo.GetCultureInfo("es-CO");

// Datos de las ventas
List<Venta> ventas =
[
    new("Portátil", "Medellín", 2, 2_800_000m),
    new("Mouse", "Bogotá", 10, 45_000m),
    new("Teclado", "Cali", 5, 120_000m),
    new("Monitor", "Medellín", 3, 750_000m),
    new("Mouse", "Medellín", 8, 45_000m),
    new("Portátil", "Bogotá", 1, 2_800_000m),
    new("Diadema", "Cali", 6, 180_000m),
    new("Monitor", "Bogotá", 2, 750_000m),
    new("Teclado", "Medellín", 4, 120_000m),
    new("Diadema", "Bogotá", 3, 180_000m),
    new("Portátil", "Cali", 2, 2_800_000m),
    new("Mouse", "Cali", 12, 45_000m)
];

// Calculamos el total vendido
decimal totalVendido = ventas.Sum(v => v.Cantidad * v.PrecioUnitario);

Console.WriteLine("===== REPORTE DE VENTAS =====");

Console.WriteLine($"\nTotal vendido: ${totalVendido.ToString("N0", cultura)}");

// Calculamos el promedio del valor de los registros de venta
decimal promedioVenta = ventas.Average(v => v.Cantidad * v.PrecioUnitario);

Console.WriteLine($"Promedio por venta: ${promedioVenta.ToString("N2", cultura)}");

// Agrupamos las ventas por ciudad y ordenamos de mayor a menor
var ventasPorCiudad = ventas
    .GroupBy(v => v.Ciudad)
    .Select(grupo => new
    {
        Ciudad = grupo.Key,
        Total = grupo.Sum(v => v.Cantidad * v.PrecioUnitario)
    })
    .OrderByDescending(v => v.Total);

Console.WriteLine("\nVentas por ciudad:");

foreach (var venta in ventasPorCiudad)
{
    Console.WriteLine($"{venta.Ciudad}: ${venta.Total.ToString("N0", cultura)}");
}

// Agrupamos los productos y calculamos sus ingresos
var topProductos = ventas
    .GroupBy(v => v.Producto)
    .Select(grupo => new
    {
        Producto = grupo.Key,
        Ingresos = grupo.Sum(v => v.Cantidad * v.PrecioUnitario)
    })
    .OrderByDescending(v => v.Ingresos)
    .Take(3);

Console.WriteLine("\nTop 3 de productos por ingresos:");

foreach (var producto in topProductos)
{
    Console.WriteLine($"{producto.Producto}: ${producto.Ingresos.ToString("N0", cultura)}");
}

// Sumamos las unidades de cada producto
var productoMasVendido = ventas
    .GroupBy(v => v.Producto)
    .Select(grupo => new
    {
        Producto = grupo.Key,
        Unidades = grupo.Sum(v => v.Cantidad)
    })
    .OrderByDescending(v => v.Unidades)
    .First();

Console.WriteLine($"\nProducto más vendido: {productoMasVendido.Producto}");
Console.WriteLine($"Unidades vendidas: {productoMasVendido.Unidades}");

// Clase que representa una venta
record Venta(string Producto, string Ciudad, int Cantidad, decimal PrecioUnitario);
