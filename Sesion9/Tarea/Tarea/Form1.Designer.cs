namespace Tarea
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
            components = new System.ComponentModel.Container();
            lblValor = new Label();
            lblUnidadValor = new Label();
            lblUnidadDestino = new Label();
            lblResultado = new Label();
            txtValor = new TextBox();
            cmbOrigen = new ComboBox();
            cmbDestino = new ComboBox();
            btnConvertir = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(38, 34);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(46, 20);
            lblValor.TabIndex = 0;
            lblValor.Text = "Valor:";
            // 
            // lblUnidadValor
            // 
            lblUnidadValor.AutoSize = true;
            lblUnidadValor.Location = new Point(38, 91);
            lblUnidadValor.Name = "lblUnidadValor";
            lblUnidadValor.Size = new Size(128, 20);
            lblUnidadValor.TabIndex = 1;
            lblUnidadValor.Text = "Unidad de origen:";
            // 
            // lblUnidadDestino
            // 
            lblUnidadDestino.AutoSize = true;
            lblUnidadDestino.Location = new Point(38, 153);
            lblUnidadDestino.Name = "lblUnidadDestino";
            lblUnidadDestino.Size = new Size(134, 20);
            lblUnidadDestino.TabIndex = 2;
            lblUnidadDestino.Text = "Unidad de destino:";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(38, 206);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(78, 20);
            lblResultado.TabIndex = 3;
            lblResultado.Text = "Resultado:";
            // 
            // txtValor
            // 
            txtValor.Location = new Point(90, 34);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(125, 27);
            txtValor.TabIndex = 4;
            // 
            // cmbOrigen
            // 
            cmbOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrigen.FormattingEnabled = true;
            cmbOrigen.Location = new Point(172, 88);
            cmbOrigen.Name = "cmbOrigen";
            cmbOrigen.Size = new Size(151, 28);
            cmbOrigen.TabIndex = 5;
            // 
            // cmbDestino
            // 
            cmbDestino.FormattingEnabled = true;
            cmbDestino.Location = new Point(172, 153);
            cmbDestino.Name = "cmbDestino";
            cmbDestino.Size = new Size(151, 28);
            cmbDestino.TabIndex = 6;
            // 
            // btnConvertir
            // 
            btnConvertir.Location = new Point(394, 122);
            btnConvertir.Name = "btnConvertir";
            btnConvertir.Size = new Size(94, 29);
            btnConvertir.TabIndex = 7;
            btnConvertir.Text = "Convertir";
            btnConvertir.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 450);
            Controls.Add(btnConvertir);
            Controls.Add(cmbDestino);
            Controls.Add(cmbOrigen);
            Controls.Add(txtValor);
            Controls.Add(lblResultado);
            Controls.Add(lblUnidadDestino);
            Controls.Add(lblUnidadValor);
            Controls.Add(lblValor);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblValor;
        private Label lblUnidadValor;
        private Label lblUnidadDestino;
        private Label lblResultado;
        private TextBox txtValor;
        private ComboBox cmbOrigen;
        private ComboBox cmbDestino;
        private Button btnConvertir;
        private ErrorProvider errorProvider1;
    }
}
