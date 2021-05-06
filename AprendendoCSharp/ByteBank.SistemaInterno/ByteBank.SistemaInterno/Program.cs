using ByteBank.Modelos;
using Humanizer;
using System;

namespace ByteBank.SistemaInterno
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(455, 253628);

            ContaCorrente conta2 = new ContaCorrente(657, 99921);

            try
            {
                conta.Sacar(150);
            }
            catch (SaldoInsuficienteException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }


            DateTime dataFimPagamento = new DateTime(2021, 6, 30);
            DateTime dataCorrente = DateTime.Now;
            TimeSpan diferenca = dataFimPagamento - dataCorrente;

            string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);

            Console.WriteLine(dataFimPagamento);
            Console.WriteLine(dataCorrente);
            Console.WriteLine(diferenca.Days);
            Console.WriteLine(mensagem);

            Console.ReadLine();
        }

    }
}
