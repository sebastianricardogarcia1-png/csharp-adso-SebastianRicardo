namespace Reto
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
            lblTitular = new Label();
            lblSaldo = new Label();
            nudMonto = new NumericUpDown();
            btnDepositar = new Button();
            btnRetirar = new Button();
            lstMovimientos = new ListBox();
            ((System.ComponentModel.ISupportInitialize)nudMonto).BeginInit();
            SuspendLayout();
            // 
            // lblTitular
            // 
            lblTitular.AutoSize = true;
            lblTitular.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitular.Location = new Point(36, 148);
            lblTitular.Name = "lblTitular";
            lblTitular.Size = new Size(164, 23);
            lblTitular.TabIndex = 0;
            lblTitular.Text = "Nombre Titular";
            lblTitular.Click += lblTitular_Click;
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSaldo.Location = new Point(36, 52);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(208, 23);
            lblSaldo.TabIndex = 1;
            lblSaldo.Text = "Saldo de la cuenta";
            lblSaldo.Click += lblSaldo_Click;
            // 
            // nudMonto
            // 
            nudMonto.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudMonto.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            nudMonto.Location = new Point(36, 94);
            nudMonto.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudMonto.Name = "nudMonto";
            nudMonto.Size = new Size(150, 30);
            nudMonto.TabIndex = 2;
            // 
            // btnDepositar
            // 
            btnDepositar.Location = new Point(590, 72);
            btnDepositar.Name = "btnDepositar";
            btnDepositar.Size = new Size(167, 29);
            btnDepositar.TabIndex = 3;
            btnDepositar.Text = "Depositar Dinero";
            btnDepositar.UseVisualStyleBackColor = true;
            btnDepositar.Click += btnDepositar_Click;
            // 
            // btnRetirar
            // 
            btnRetirar.Location = new Point(590, 122);
            btnRetirar.Name = "btnRetirar";
            btnRetirar.Size = new Size(153, 29);
            btnRetirar.TabIndex = 4;
            btnRetirar.Text = "Retirar Dinero";
            btnRetirar.UseVisualStyleBackColor = true;
            btnRetirar.Click += btnRetirar_Click;
            // 
            // lstMovimientos
            // 
            lstMovimientos.FormattingEnabled = true;
            lstMovimientos.Location = new Point(590, 204);
            lstMovimientos.Name = "lstMovimientos";
            lstMovimientos.Size = new Size(150, 104);
            lstMovimientos.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstMovimientos);
            Controls.Add(btnRetirar);
            Controls.Add(btnDepositar);
            Controls.Add(nudMonto);
            Controls.Add(lblSaldo);
            Controls.Add(lblTitular);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudMonto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitular;
        private Label lblSaldo;
        private NumericUpDown nudMonto;
        private Button btnDepositar;
        private Button btnRetirar;
        private ListBox lstMovimientos;
    }
}
