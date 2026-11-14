using System;
using Inventario.Datos;
using Inventario.Modelos;
using Inventario.Servicios;

var servicio = new ServicioInventario(new RepositorioJson("inventario.json"));
bool salir = false;

while (!salir)
{
    Console.WriteLine("\n=== GESTIÓN DE INVENTARIO ===");
    Console.WriteLine("1. Registrar producto");
    Console.WriteLine("2. Agregar stock");
    Console.WriteLine("3. Vender producto");
    Console.WriteLine("4. Ver inventario completo");
    Console.WriteLine("5. Ver productos con stock bajo (< 5)");
    Console.WriteLine("6. Buscar producto por texto");
    Console.WriteLine("7. Eliminar producto");
    Console.WriteLine("8. Salir");
    Console.Write("Elige una opción: ");

    string opcion = Console.ReadLine() ?? "";

    try
    {
        switch (opcion)
        {
            case "1":
                Console.Write("Código: ");
                string cod = Console.ReadLine() ?? "";
                Console.Write("Nombre: ");
                string nom = Console.ReadLine() ?? "";
                Console.Write("Precio: ");
                decimal precio = decimal.Parse(Console.ReadLine() ?? "");
                Console.Write("Stock inicial: ");
                int stock = int.Parse(Console.ReadLine() ?? "");

                servicio.Agregar(new Producto(cod, nom, precio, stock));
                Console.WriteLine("✅ Producto registrado con éxito.");
                break;

            case "2":
                Console.Write("Código del producto: ");
                string codStock = Console.ReadLine() ?? "";
                Console.Write("Cantidad a agregar: ");
                int cantAdd = int.Parse(Console.ReadLine() ?? "");

                servicio.AgregarStock(codStock, cantAdd);
                Console.WriteLine("✅ Stock actualizado.");
                break;

            case "3":
                Console.Write("Código del producto: ");
                string codVenta = Console.ReadLine() ?? "";
                Console.Write("Cantidad a vender: ");
                int cantVenta = int.Parse(Console.ReadLine() ?? "");

                servicio.Vender(codVenta, cantVenta);
                Console.WriteLine("✅ Venta realizada.");
                break;

            case "4":
                var todos = servicio.Listar();
                Console.WriteLine("\n--- INVENTARIO ---");
                if (todos.Count == 0) Console.WriteLine("No hay productos registrados.");
                foreach (var p in todos)
                    Console.WriteLine($"[{p.Codigo}] {p.Nombre} - Precio: ${p.Precio} - Stock: {p.Stock}");
                break;

            case "5":
                var bajos = servicio.StockBajo();
                Console.WriteLine("\n--- STOCK BAJO ---");
                if (bajos.Count == 0) Console.WriteLine("Todo tiene buen stock.");
                foreach (var p in bajos)
                    Console.WriteLine($"⚠️ [{p.Codigo}] {p.Nombre} - Stock: {p.Stock}");
                break;

            case "6":
                Console.Write("Escribe nombre o código a buscar: ");
                string texto = Console.ReadLine() ?? "";
                var encontrados = servicio.BuscarPorTexto(texto);
                Console.WriteLine("\n--- RESULTADOS ---");
                if (encontrados.Count == 0) Console.WriteLine("No se encontraron coincidencias.");
                foreach (var p in encontrados)
                    Console.WriteLine($"[{p.Codigo}] {p.Nombre} - Precio: ${p.Precio} - Stock: {p.Stock}");
                break;

            case "7":
                Console.Write("Código del producto a eliminar: ");
                string codEliminar = Console.ReadLine() ?? "";
                Console.Write($"¿Seguro que deseas eliminar el producto {codEliminar}? (s/n): ");
                string confirmacion = Console.ReadLine()?.Trim().ToLower() ?? "";

                if (confirmacion == "s")
                {
                    servicio.Eliminar(codEliminar);
                    Console.WriteLine("🗑️ Producto eliminado.");
                }
                else
                {
                    Console.WriteLine("Operación cancelada.");
                }
                break;

            case "8":
                salir = true;
                break;

            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("❌ Error: Debes ingresar un número válido para precios o cantidades.");
    }
    catch (StockInsuficienteException ex)
    {
        Console.WriteLine($"❌ {ex.Message}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"❌ {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error inesperado: {ex.Message}");
    }
}