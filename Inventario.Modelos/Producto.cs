using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Modelos
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public Producto(string codigo, string nombre, decimal precio, int stock)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }

        public void Vender(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad a vender debe ser mayor a cero.");

            if (cantidad > Stock)
                throw new StockInsuficienteException(Nombre, Stock);

            Stock -= cantidad;
        }

        public void AgregarStock(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad a agregar debe ser mayor a cero.");

            Stock += cantidad;
        }
    }
}