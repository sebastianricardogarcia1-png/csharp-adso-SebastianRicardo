using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Modelos;

namespace Inventario.Datos
{
    public interface IRepositorioProductos
    {
        List<Producto> ObtenerTodos();
        Producto? BuscarPorCodigo(string codigo);
        void Agregar(Producto producto);
        void Actualizar(Producto producto);
        void Eliminar(string codigo);
    }
}