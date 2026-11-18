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
        public Producto? ProductoCreado { get; private set; }

        public FormProducto()
        {
            InitializeComponent();
        }

        private void FormProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Usamos el constructor con los parámetros que exige la clase Producto
                ProductoCreado = new Producto(
                    txtCodigo.Text,
                    txtNombre.Text,
                    decimal.Parse(txtPrecio.Text),
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