using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarregarContas();
            }
            catch (Exception)
            {
                Console.WriteLine("Catch no metodo main");
            }

            Console.WriteLine("Execução finalizada! Tecle enter para sair");
            Console.ReadLine();
        }
        private static void CarregarContas()
        {
            using (LeitorDeArquivos leitor = new LeitorDeArquivos("teste.txt"))
            {
                leitor.LerProximaLinha();
            }

            //LeitorDeArquivos leitor = null;

            //try
            //{
            //    leitor = new LeitorDeArquivos("contas.txt");

            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //}
            //catch (IOException) //FileNotFound é uma IOException também
            //{
            //    Console.WriteLine("Exceção do tipo IOException capturada e tratada");
            //}
            //finally
            //{
            //    Console.WriteLine("Executando o finally");
            //    if(leitor != null)
            //    {
            //        leitor.Fechar();
            //    }
            //}
        }
        private static void TestaExceptions()
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(12210, 110);
                ContaCorrente conta2 = new ContaCorrente(12211, 100);
                //conta1.Transferir(1500, conta2);
                conta1.Sacar(1500);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Ocorreu um erro do tipo ArgumentException");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

            }
            catch (SaldoInsuficienteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
