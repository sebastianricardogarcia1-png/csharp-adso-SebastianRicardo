using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inventario.Modelos;

namespace Inventario.Escritorio
{
    public partial class FormReportes : Form
    {
        private readonly List<Producto> _productos;

        public FormReportes(IEnumerable<Producto> productos)
        {
            InitializeComponent();
            _productos = productos.ToList();
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            // Tabla 1: Productos más valiosos (ordenados de mayor a menor por valor total)
            dgvMasValiosos.DataSource = null;
            dgvMasValiosos.DataSource = _productos
                .OrderByDescending(p => p.Precio * p.Stock)
                .ToList();

            // Tabla 2: Productos con stock bajo (menor a 5 unidades)
            dgvStockBajo.DataSource = null;
            dgvStockBajo.DataSource = _productos
                .Where(p => p.Stock < 5)
                .ToList();
        }
    }
}