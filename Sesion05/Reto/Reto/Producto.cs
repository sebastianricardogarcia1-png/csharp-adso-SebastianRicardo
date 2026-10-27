
namespace Reto
{
    internal class Producto
    {
        private string nombre = string.Empty;
        private decimal precio;

        public string Codigo { get; private set; }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre no puede estar vacío.");
                }

                nombre = value.Trim();
            }
        }

        public decimal Precio
        {
            get { return precio; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("El precio debe ser mayor que cero.");
                }

                precio = value;
            }
        }

        public int Stock { get; private set; }

        public Producto(string codigo, string nombre, decimal precio, int stock)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                throw new ArgumentException("El código es obligatorio.");
            }

            if (stock < 0)
            {
                throw new ArgumentException("El stock no puede ser negativo.");
            }

            Codigo = codigo.Trim().ToUpper();
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }

        public void AgregarStock(int cantidad)
        {
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor que cero.");
            }

            Stock += cantidad;
        }

        public bool Vender(int cantidad)
        {
            if (cantidad <= 0 || cantidad > Stock)
            {
                return false;
            }

            Stock -= cantidad;
            return true;
        }
    }
}
