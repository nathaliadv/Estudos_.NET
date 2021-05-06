using System;

namespace _2_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente();

            conta.titular = "Nathalia";

            Console.WriteLine(conta.titular);
            Console.WriteLine(conta.saldo);

            Console.ReadLine();
        }
    }
}
