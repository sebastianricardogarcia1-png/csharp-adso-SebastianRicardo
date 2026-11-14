using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inventario.Datos;
using Inventario.Modelos;

namespace Inventario.Servicios
{
    public class ServicioInventario
    {
        private readonly IRepositorioProductos _repositorio;

        public ServicioInventario(IRepositorioProductos repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Producto> Listar()
        {
            return _repositorio.ObtenerTodos().OrderBy(p => p.Nombre).ToList();
        }

        public void Agregar(Producto nuevo)
        {
            if (_repositorio.BuscarPorCodigo(nuevo.Codigo) != null)
                throw new ArgumentException($"Ya existe un producto con el código {nuevo.Codigo}.");

            _repositorio.Agregar(nuevo);
        }

        public void AgregarStock(string codigo, int cantidad)
        {
            Producto producto = _repositorio.BuscarPorCodigo(codigo)
                ?? throw new ArgumentException($"No existe el producto {codigo}.");

            producto.AgregarStock(cantidad);
            _repositorio.Actualizar(producto);
        }

        public void Vender(string codigo, int cantidad)
        {
            Producto producto = _repositorio.BuscarPorCodigo(codigo)
                ?? throw new ArgumentException($"No existe el producto {codigo}.");

            producto.Vender(cantidad);
            _repositorio.Actualizar(producto);
        }

        public List<Producto> StockBajo()
        {
            return _repositorio.ObtenerTodos().Where(p => p.Stock < 5).ToList();
        }

        public List<Producto> BuscarPorTexto(string texto)
        {
            return _repositorio.ObtenerTodos()
                .Where(p => p.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)
                         || p.Codigo.Contains(texto, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public void Eliminar(string codigo)
        {
            if (_repositorio.BuscarPorCodigo(codigo) == null)
                throw new ArgumentException($"No existe el producto {codigo}.");

            _repositorio.Eliminar(codigo);
        }
    }
}