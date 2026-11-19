namespace Inventario.Escritorio
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnNuevo = new Button();
            btnVender = new Button();
            btnAgregarStock = new Button();
            btnEliminar = new Button();
            lblValorTotal = new Label();
            nudCantidad = new NumericUpDown();
            txtBuscar = new TextBox();
            dgvProductos = new DataGridView();
            btnReportes = new Button();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(43, 142);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(192, 29);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo Producto";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnVender
            // 
            btnVender.Location = new Point(90, 39);
            btnVender.Name = "btnVender";
            btnVender.Size = new Size(94, 29);
            btnVender.TabIndex = 1;
            btnVender.Text = "Vender";
            btnVender.UseVisualStyleBackColor = true;
            // 
            // btnAgregarStock
            // 
            btnAgregarStock.Location = new Point(219, 25);
            btnAgregarStock.Name = "btnAgregarStock";
            btnAgregarStock.Size = new Size(94, 29);
            btnAgregarStock.TabIndex = 2;
            btnAgregarStock.Text = "Agregar Stock";
            btnAgregarStock.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(12, 199);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // lblValorTotal
            // 
            lblValorTotal.AutoSize = true;
            lblValorTotal.Location = new Point(134, 97);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(217, 20);
            lblValorTotal.TabIndex = 4;
            lblValorTotal.Text = "Valor Total del Inventario: $0.00";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(387, 129);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(150, 27);
            nudCantidad.TabIndex = 5;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(12, 351);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(125, 27);
            txtBuscar.TabIndex = 6;
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(237, 190);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.Size = new Size(300, 188);
            dgvProductos.TabIndex = 7;
            dgvProductos.CellDoubleClick += dgvProductos_CellDoubleClick;
            // 
            // btnReportes
            // 
            btnReportes.Location = new Point(400, 39);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(94, 29);
            btnReportes.TabIndex = 8;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 450);
            Controls.Add(btnReportes);
            Controls.Add(dgvProductos);
            Controls.Add(txtBuscar);
            Controls.Add(nudCantidad);
            Controls.Add(lblValorTotal);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregarStock);
            Controls.Add(btnVender);
            Controls.Add(btnNuevo);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNuevo;
        private Button btnVender;
        private Button btnAgregarStock;
        private Button btnEliminar;
        private Label lblValorTotal;
        private NumericUpDown nudCantidad;
        private TextBox txtBuscar;
        private DataGridView dgvProductos;
        private Button btnReportes;
    }
}
