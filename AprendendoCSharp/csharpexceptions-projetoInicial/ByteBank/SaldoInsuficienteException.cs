using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {
        public double Saldo { get;}
        public double ValorSaque { get;}
        //pode ser criado um objeto deste tipo passando uma mensagem ou não.
        public SaldoInsuficienteException()
        {

        }

        //novo construtor que chama o outro construtor já existente (usando o this)
        public SaldoInsuficienteException(double saldo, double valorSaque) 
            : this($"Saldo insuficiente para o valor de R${valorSaque}. Seu saldo atual é de R${saldo}.")
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }
        public SaldoInsuficienteException(string mensagem) : base(mensagem)
        {
            
        }
        public SaldoInsuficienteException(string mensagem, Exception excecaoInterna) : base(mensagem, excecaoInterna)
        {

        }
    }
}
