using System;

namespace ByteBank.Modelos
{   /// <summary>
    /// Define uma conta corrente do banco ByteBank.
    /// </summary>
    public class ContaCorrente : IComparable
    {
        private static double TaxaOperacao;
        public static int TotalDeContasCriadas { get; private set; }
        public Cliente Titular { get; set; }

        //private readonly int _numero;
        public int Numero { get; }

        //private readonly int _agencia;
        public int Agencia { get;}

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
        }

        public int ContadorSaquesNegados { get; private set; }
        public int ContadorTransferenciasNegadas { get; private set; }

        /// <summary>
        /// Cria uma instância de ContaCorrente com os argumentos utilizados.
        /// </summary>
        /// <param name="agencia">Representa o valor da propriedade <see cref="Agencia"/> e deve ser maior que zero.</param>
        /// <param name="numero">Representa o valor da propriedade <see cref="Numero"/> e deve ser maior que zero.</param>
        public ContaCorrente(int agencia, int numero)
        {
            if(agencia <= 0)
            {
                throw new ArgumentException("A Agência deve ter um valor maior que zero.", nameof(agencia));
            }

            if(numero <= 0) 
            {
                throw new ArgumentException("O Número da conta deve ter um valor maior que zero.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero; 

            TotalDeContasCriadas++;

            TaxaOperacao = 30 / TotalDeContasCriadas;

        }

        /// <summary>
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Saldo"/>.
        /// </summary>
        /// <exception cref="ArgumentException">Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/>.</exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando o valor de <paramref name="valor"/> é maior que o valor da propriedade <see cref="Saldo"/>.</exception>
        /// <param name="valor">Representa o valor do saque. Deve ser maior que zero e menor que o <see cref="Saldo"/></param>
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido. Digite um valor maior que zero para realizar saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNegados++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido. Digite um valor maior que zero para realizar depósito.", nameof(valor));
            }
            _saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido. Digite um valor maior que zero para realizar a transferência.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch(SaldoInsuficienteException e)
            {
                ContadorTransferenciasNegadas++;
                throw new OperacaoFinanceiraException("Não é possível realizar a operação. Saldo insuficiente!", e);
            }
            contaDestino.Depositar(valor);
        }

        public override string ToString()
        {
            return $"Agência: {Agencia} | Número: {Numero}";
        }

        public override bool Equals(object obj)
        {
            ContaCorrente outraConta = obj as ContaCorrente;

            if(outraConta == null)
            {
                return false;
            }

            return Numero == outraConta.Numero && Agencia == outraConta.Agencia; //false or true
            //if(Numero == outraConta.Numero && Agencia == outraConta.Agencia)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public int CompareTo(object obj)
        {
            //Regras determinadas dentro da interface:
            //Retornar negativo quando a instancia precede o obj (argumento)
            //Retornar zero quando a instancia e o obj forem equivalentes
            //Retornar positivo diferente de zero quando a precedencia for de obj

            var outraConta = obj as ContaCorrente;

            if(outraConta == null) //decisão tomada para tratar a exceção que poderia acontecer caso a conta corrente tenha referencia nula
            {
                return -1;
            }

            if(Numero < outraConta.Numero)
            {
                return -1;
            }
            if (Numero == outraConta.Numero)
            {
                return 0;
            }
            return 1;
        }
    }
}
