// using _05_ByteBank;

using System;

namespace ByteBank
{
    public class ContaCorrente
    {
        public static int TotalDeContasCriadas { get; private set; }
        public static double TaxaOperacao { get; private set; }
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
    }
}
