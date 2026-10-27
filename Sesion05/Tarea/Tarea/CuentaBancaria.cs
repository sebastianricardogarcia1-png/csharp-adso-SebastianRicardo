
namespace Tarea
{
    internal class CuentaBancaria
    {
        public string Titular { get; private set; }
        public string Numero { get; private set; }
        public decimal Saldo { get; private set; }

        public CuentaBancaria(string titular, string numero, decimal saldoInicial = 0)
        {
            Titular = titular;
            Numero = numero;
            Saldo = saldoInicial;
        }

        public bool Depositar(decimal monto)
        {
            if (monto <= 0)
            {
                return false;
            }

            Saldo += monto;
            return true;
        }

        public bool Retirar(decimal monto)
        {
            if (monto <= 0 || monto > Saldo)
            {
                return false;
            }

            Saldo -= monto;
            return true;
        }

        public bool Transferir(CuentaBancaria destino, decimal monto)
        {
            if (destino == null || monto <= 0 || monto > Saldo)
            {
                return false;
            }

            Saldo -= monto;
            destino.Saldo += monto;

            return true;
        }
    }
}
