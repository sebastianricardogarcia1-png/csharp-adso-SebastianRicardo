using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Modelos
{
    public class StockInsuficienteException : Exception
    {
        public StockInsuficienteException(string producto, int disponible)
            : base($"No hay suficiente {producto}. Disponible: {disponible}.")
        {
        }
    }
}