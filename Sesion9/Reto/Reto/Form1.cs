using static System.Net.Mime.MediaTypeNames;

namespace Reto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ActualizarSaldo();
            lblTitular.Text = _cuenta.Titular;
        }

        private void ActualizarSaldo()
        {
            lblSaldo.Text = _cuenta.Saldo.ToString();
        }
        private readonly CuentaBancaria _cuenta = new("Sebastian", "001-123", 500000m);

        private void lblTitular_Click(object sender, EventArgs e)
        {

        }

        private void lblSaldo_Click(object sender, EventArgs e)
        {

        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            decimal monto = nudMonto.Value;

            try
            {
                _cuenta.Depositar(monto);

                ActualizarSaldo();

                string texto = $"{DateTime.Now:HH:mm:ss} - Depósito - {monto:C}";

                lstMovimientos.Items.Insert(0, texto);

                MessageBox.Show("Depósito realizado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al depositar",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            decimal monto = nudMonto.Value;

            try
            {
                _cuenta.Retirar(monto);

                ActualizarSaldo();

                string texto = $"{DateTime.Now:HH:mm:ss} - Retiro - {monto:C}";

                lstMovimientos.Items.Insert(0, texto);

                MessageBox.Show("Retiro realizado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al retirar",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
