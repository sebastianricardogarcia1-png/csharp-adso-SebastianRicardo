using System;
using System.Drawing;
using System.Windows.Forms;
using Inventario.Servicios;
using Inventario.Modelos;
using Inventario.Datos;

namespace Inventario.Escritorio
{
    public partial class Form1 : Form
    {
        private readonly ServicioInventario _servicio;

        public Form1()
        {
            InitializeComponent();
            _servicio = new ServicioInventario(new RepositorioJson("productos.json"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = _servicio.Listar();
            ActualizarValorTotal();
        }

        private void ActualizarValorTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.DataBoundItem is Producto p)
                {
                    total += p.Precio * p.Stock;
                }
            }
            lblValorTotal.Text = $"Valor Total del Inventario: {total:C2}";
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProductos.Columns[e.ColumnIndex].Name == "Precio" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal precio))
                {
                    e.Value = precio.ToString("C2");
                    e.FormattingApplied = true;
                }
            }

            if (dgvProductos.Rows[e.RowIndex].DataBoundItem is Producto producto && producto.Stock < 5)
            {
                dgvProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            var resultados = _servicio.BuscarPorTexto(txtBuscar.Text);
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = resultados;
            ActualizarValorTotal();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormProducto frm = new FormProducto();
            if (frm.ShowDialog() == DialogResult.OK && frm.ProductoCreado != null)
            {
                try
                {
                    _servicio.Agregar(frm.ProductoCreado);
                    CargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is not Producto producto)
            {
                MessageBox.Show("Selecciona un producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _servicio.Vender(producto.Codigo, (int)nudCantidad.Value);
                CargarProductos();
            }
            catch (StockInsuficienteException ex)
            {
                MessageBox.Show(ex.Message, "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregarStock_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is not Producto producto)
            {
                MessageBox.Show("Selecciona un producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _servicio.AgregarStock(producto.Codigo, (int)nudCantidad.Value);
            CargarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is not Producto producto)
            {
                MessageBox.Show("Selecciona un producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resultado = MessageBox.Show($"¿Deseas eliminar el producto {producto.Nombre}?",
                                            "Confirmar eliminación",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                _servicio.Eliminar(producto.Codigo);
                CargarProductos();
            }
        }
    }
}