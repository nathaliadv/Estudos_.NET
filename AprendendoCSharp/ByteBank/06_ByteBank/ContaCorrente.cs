
namespace _06_ByteBank
{
    public class ContaCorrente
    {   /*
        public Cliente titular;
        public int agencia;
        public int numero; */
        private double _saldo = 100.0;
        public Cliente Titular { get; set; } //declarar apenas a propriedade já que não há um conjunto de regras para o get e set.
        public int Agencia { get; set; }
        public int Numero { get; set; }

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            
            set
            {
                if(value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        /*
        public void SetSaldo(double saldo)
        {
            if(saldo < 0)
            {
                return;
            }
            
            this.saldo = saldo;
            
        }

        public double GetSaldo()
        {
            return this.saldo;      
        }

        */

        //nos lugares onde não há colisão de nome poderia ter declarado apenas como saldo. Sem usar o this
        public bool Sacar(double valor)
        {
            if (this._saldo < valor)
            {
                return false;
            }

            this._saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            this._saldo += valor;
        }

        public bool Tranferir(double valor, ContaCorrente contaDestino)
        {
            if (this._saldo < valor)
            {
                return false;
            }

            this._saldo -= valor;
            contaDestino.Depositar(valor);
            return true;

        }
    }

}
