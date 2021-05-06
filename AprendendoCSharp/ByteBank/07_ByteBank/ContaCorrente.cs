
namespace _07_ByteBank
{
    public class ContaCorrente
    {
        private int _agencia;
        private int _numero;
        private double _saldo = 100.0;
        public Cliente Titular { get; set; }
        public static int TotalDeContasCriadas { get; private set; }
        public int Agencia {
            get
            {
                return _agencia;
            }
            set
            {
                if(value < 0)
                {
                    return;
                }

                _agencia = value;
            }
        }
        public int Numero
        {
            get
            {
                return _numero
;           }
            set
            {
                if(value < 0)
                {
                    return;
                }

                _numero = value;
            }
        }

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

        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
        }

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
