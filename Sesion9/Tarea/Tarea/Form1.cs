
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Tarea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Agregamos las unidades de temperatura
            cmbOrigen.Items.Add("Celsius");
            cmbOrigen.Items.Add("Fahrenheit");
            cmbOrigen.Items.Add("Kelvin");

            cmbDestino.Items.Add("Celsius");
            cmbDestino.Items.Add("Fahrenheit");
            cmbDestino.Items.Add("Kelvin");
        }

        private void BtnConvertir_Click(object sender, EventArgs e)
        {
            // Limpiamos los errores anteriores
            errorProvider1.Clear();

            // Validamos que el valor sea numérico
            if (!double.TryParse(txtValor.Text, NumberStyles.Float,
                CultureInfo.CurrentCulture, out double valor))
            {
                errorProvider1.SetError(txtValor, "Ingrese un número válido");
                return;
            }

            // Validamos la unidad de origen
            if (cmbOrigen.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbOrigen, "Seleccione una unidad de origen");
                return;
            }

            // Validamos la unidad de destino
            if (cmbDestino.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbDestino, "Seleccione una unidad de destino");
                return;
            }

            // Obtenemos las unidades seleccionadas
            string origen = cmbOrigen.SelectedItem as string ?? "";
            string destino = cmbDestino.SelectedItem as string ?? "";

            // Realizamos la conversión
            double resultado = ConversorTemperatura.Convertir(valor, origen, destino);

            // Mostramos el resultado
            lblResultado.Text = "Resultado: " + resultado.ToString("F2");
        }
    }
}
