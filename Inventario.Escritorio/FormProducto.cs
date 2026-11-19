using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Inventario.Modelos;

namespace Inventario.Escritorio
{
    public partial class FormProducto : Form
    {
        private readonly bool _esEdicion;

        public Producto? ProductoCreado { get; private set; }
        public string NombreEditado => txtNombre.Text.Trim();
        public decimal PrecioEditado => decimal.Parse(txtPrecio.Text);

        public FormProducto()
        {
            InitializeComponent();
            _esEdicion = false;
        }

        public FormProducto(Producto productoExistente)
        {
            InitializeComponent();
            _esEdicion = true;

            txtCodigo.Text = productoExistente.Codigo;
            txtNombre.Text = productoExistente.Nombre;
            txtPrecio.Text = productoExistente.Precio.ToString();
            txtStock.Text = productoExistente.Stock.ToString();

            txtCodigo.Enabled = false;
            txtStock.Enabled = false;
        }

        private void FormProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal precio = decimal.Parse(txtPrecio.Text);

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    throw new ArgumentException("El nombre no puede estar vacío.");

                if (precio <= 0)
                    throw new ArgumentException("El precio debe ser mayor a cero.");

                if (_esEdicion)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                // Usamos el constructor con los parámetros que exige la clase Producto
                ProductoCreado = new Producto(
                    txtCodigo.Text.Trim(),
                    txtNombre.Text.Trim(),
                    precio,
                    int.Parse(txtStock.Text)
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor, verifica que los datos sean correctos.\nDetalle: " + ex.Message,
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}