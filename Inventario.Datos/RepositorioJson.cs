using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Inventario.Modelos;

namespace Inventario.Datos
{
    public class RepositorioJson : IRepositorioProductos
    {
        private readonly string _ruta;

        public RepositorioJson(string ruta)
        {
            _ruta = ruta;
        }

        public List<Producto> ObtenerTodos()
        {
            if (!File.Exists(_ruta)) return [];
            try
            {
                string json = File.ReadAllText(_ruta);
                return JsonSerializer.Deserialize<List<Producto>>(json) ?? [];
            }
            catch (JsonException)
            {
                File.Copy(_ruta, _ruta + ".danado", overwrite: true);
                return [];
            }
        }

        private void Guardar(List<Producto> lista)
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(_ruta, JsonSerializer.Serialize(lista, opciones));
        }

        public Producto? BuscarPorCodigo(string codigo)
        {
            var lista = ObtenerTodos();
            return lista.FirstOrDefault(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        }

        public void Agregar(Producto producto)
        {
            var lista = ObtenerTodos();
            lista.Add(producto);
            Guardar(lista);
        }

        public void Actualizar(Producto producto)
        {
            var lista = ObtenerTodos();
            int i = lista.FindIndex(p => p.Codigo.Equals(producto.Codigo, StringComparison.OrdinalIgnoreCase));
            if (i >= 0)
            {
                lista[i] = producto;
                Guardar(lista);
            }
        }

        public void Eliminar(string codigo)
        {
            var lista = ObtenerTodos();
            int eliminados = lista.RemoveAll(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
            if (eliminados > 0)
            {
                Guardar(lista);
            }
        }
    }
}