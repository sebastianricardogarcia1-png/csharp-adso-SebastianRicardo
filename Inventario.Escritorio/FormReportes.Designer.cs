namespace Inventario.Escritorio
{
    partial class FormReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvMasValiosos = new DataGridView();
            dgvStockBajo = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMasValiosos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStockBajo).BeginInit();
            SuspendLayout();
            // 
            // dgvMasValiosos
            // 
            dgvMasValiosos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMasValiosos.Location = new Point(12, 218);
            dgvMasValiosos.Name = "dgvMasValiosos";
            dgvMasValiosos.RowHeadersWidth = 51;
            dgvMasValiosos.Size = new Size(300, 188);
            dgvMasValiosos.TabIndex = 0;
            // 
            // dgvStockBajo
            // 
            dgvStockBajo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStockBajo.Location = new Point(12, 12);
            dgvStockBajo.Name = "dgvStockBajo";
            dgvStockBajo.RowHeadersWidth = 51;
            dgvStockBajo.Size = new Size(300, 188);
            dgvStockBajo.TabIndex = 1;
            // 
            // FormReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvStockBajo);
            Controls.Add(dgvMasValiosos);
            Name = "FormReportes";
            Text = "FormReportes";
            ((System.ComponentModel.ISupportInitialize)dgvMasValiosos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStockBajo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMasValiosos;
        private DataGridView dgvStockBajo;
    }
}