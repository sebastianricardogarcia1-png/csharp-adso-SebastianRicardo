
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reto;

public record LineaVenta(
    string Codigo,
    string Nombre,
    int Cantidad,
    decimal Subtotal
);

public record Factura(
    int Numero,
    DateTime Fecha,
    List<LineaVenta> Lineas,
    decimal Total
);

class Program
{
    static void Main()
    {
        List<Producto> inventario =
        [
            new Producto("P001", "Portatil", 2800000m, 5),
            new Producto("P002", "Mouse", 45000m, 20),
            new Producto("P003", "Teclado", 80000m, 10)
        ];

        List<LineaVenta> carrito = new();

        int numeroFactura = 1;
        int opcion;

        do
        {
            Console.WriteLine("\n===== TIENDA =====");
            Console.WriteLine("1. Registrar producto");
            Console.WriteLine("2. Agregar stock");
            Console.WriteLine("3. Vender producto");
            Console.WriteLine("4. Ver carrito");
            Console.WriteLine("5. Ver inventario");
            Console.WriteLine("6. Confirmar compra y generar factura");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese una opción válida.");
                opcion = 0;
                continue;
            }

            switch (opcion)
            {
                case 1:
                    RegistrarProducto(inventario);
                    break;

                case 2:
                    AgregarStock(inventario);
                    break;

                case 3:
                    VenderProducto(inventario, carrito);
                    break;

                case 4:
                    VerCarrito(carrito);
                    break;

                case 5:
                    VerInventario(inventario);
                    break;

                case 6:
                    ConfirmarCompra(carrito, ref numeroFactura);
                    break;

                case 7:
                    Console.WriteLine("Gracias por utilizar la tienda.");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 7);
    }

    static void RegistrarProducto(List<Producto> inventario)
    {
        try
        {
            Console.Write("Código: ");
            string codigo = Console.ReadLine() ?? "";

            if (inventario.Any(p => p.Codigo == codigo.Trim().ToUpper()))
            {
                Console.WriteLine("Ya existe un producto con ese código.");
                return;
            }

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Precio: ");

            if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
            {
                Console.WriteLine("Ingrese un precio válido.");
                return;
            }

            Console.Write("Stock inicial: ");

            if (!int.TryParse(Console.ReadLine(), out int stock))
            {
                Console.WriteLine("Ingrese una cantidad válida.");
                return;
            }

            Producto producto = new Producto(codigo, nombre, precio, stock);

            inventario.Add(producto);

            Console.WriteLine("Producto registrado correctamente.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void AgregarStock(List<Producto> inventario)
    {
        Console.Write("Código del producto: ");
        string codigo = (Console.ReadLine() ?? "").Trim().ToUpper();

        Producto? producto = inventario.FirstOrDefault(
            p => p.Codigo == codigo
        );

        if (producto == null)
        {
            Console.WriteLine("El producto no existe.");
            return;
        }

        Console.Write("Cantidad que desea agregar: ");

        if (!int.TryParse(Console.ReadLine(), out int cantidad))
        {
            Console.WriteLine("Ingrese una cantidad válida.");
            return;
        }

        try
        {
            producto.AgregarStock(cantidad);
            Console.WriteLine("Stock actualizado correctamente.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void VenderProducto(
        List<Producto> inventario,
        List<LineaVenta> carrito)
    {
        Console.Write("Código del producto: ");
        string codigo = (Console.ReadLine() ?? "").Trim().ToUpper();

        Producto? producto = inventario.FirstOrDefault(
            p => p.Codigo == codigo
        );

        if (producto == null)
        {
            Console.WriteLine("El producto no existe.");
            return;
        }

        Console.Write("Cantidad que desea vender: ");

        if (!int.TryParse(Console.ReadLine(), out int cantidad))
        {
            Console.WriteLine("Ingrese una cantidad válida.");
            return;
        }

        if (!producto.Vender(cantidad))
        {
            Console.WriteLine("Cantidad inválida o stock insuficiente.");
            return;
        }

        decimal subtotal = producto.Precio * cantidad;

        LineaVenta linea = new LineaVenta(
            producto.Codigo,
            producto.Nombre,
            cantidad,
            subtotal
        );

        carrito.Add(linea);

        Console.WriteLine("Producto agregado al carrito.");
    }

    static void VerCarrito(List<LineaVenta> carrito)
    {
        Console.WriteLine("\n===== CARRITO DE COMPRAS =====");

        if (carrito.Count == 0)
        {
            Console.WriteLine("El carrito está vacío.");
            return;
        }

        foreach (LineaVenta linea in carrito)
        {
            Console.WriteLine(
                $"{linea.Nombre} | Cantidad: {linea.Cantidad} | " +
                $"Subtotal: {linea.Subtotal:C0}"
            );
        }

        decimal total = carrito.Sum(l => l.Subtotal);

        Console.WriteLine($"TOTAL: {total:C0}");
    }

    static void VerInventario(List<Producto> inventario)
    {
        Console.WriteLine("\n===== INVENTARIO =====");

        foreach (Producto producto in inventario)
        {
            Console.WriteLine(
                $"Código: {producto.Codigo} | " +
                $"Nombre: {producto.Nombre} | " +
                $"Precio: {producto.Precio:C0} | " +
                $"Stock: {producto.Stock}"
            );
        }
    }

    static void ConfirmarCompra(
        List<LineaVenta> carrito,
        ref int numeroFactura)
    {
        if (carrito.Count == 0)
        {
            Console.WriteLine("No hay productos para facturar.");
            return;
        }

        List<LineaVenta> lineasFactura = new(carrito);

        decimal total = lineasFactura.Sum(l => l.Subtotal);

        Factura factura = new Factura(
            numeroFactura,
            DateTime.Now,
            lineasFactura,
            total
        );

        Console.WriteLine("\n======= FACTURA =======");
        Console.WriteLine($"Factura N.º: {factura.Numero}");
        Console.WriteLine($"Fecha: {factura.Fecha:dd/MM/yyyy HH:mm}");
        Console.WriteLine("-----------------------");

        foreach (LineaVenta linea in factura.Lineas)
        {
            Console.WriteLine(
                $"{linea.Nombre} x {linea.Cantidad} = {linea.Subtotal:C0}"
            );
        }

        Console.WriteLine("-----------------------");
        Console.WriteLine($"TOTAL A PAGAR: {factura.Total:C0}");
        Console.WriteLine("=======================");

        numeroFactura++;
        carrito.Clear();

        Console.WriteLine("Compra facturada correctamente.");
    }
}
