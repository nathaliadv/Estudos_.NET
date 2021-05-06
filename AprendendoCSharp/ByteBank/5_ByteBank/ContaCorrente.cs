//using _05_ByteBank; especifica que serão usadas as classes desse namespace.

namespace _05_ByteBank
{
    public class ContaCorrente
    {
        //public _05_ByteBank.Cliente titular;
        public Cliente titular;
        //public Cliente titular = new Cliente(); instanciando cliente quando a classe contaCorrente for instanciada
        public int agencia;
        public int numero;
        public double saldo = 100.0;

        public bool Sacar(double valor)
        {
            if (this.saldo < valor)
            {
                return false;
            }

            this.saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            this.saldo += valor;
        }

        public bool Tranferir(double valor, ContaCorrente contaDestino)
        {
            if (this.saldo < valor)
            {
                return false;
            }

            this.saldo -= valor;
            contaDestino.Depositar(valor);
            return true;

        }
    }

}
