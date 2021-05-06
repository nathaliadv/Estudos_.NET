using System;

namespace _05_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cliente nathalia = new Cliente();

            //nathalia.nome = "Nathalia";
            //nathalia.profissao = "Dev";
            //nathalia.cpf = "12345678910";

            ContaCorrente conta = new ContaCorrente();

            //conta.titular = nathalia;
            conta.titular = new Cliente();
            conta.titular.nome = "Nathalia";
            conta.titular.cpf = "12345678910";
            conta.titular.profissao = "Dev";
            conta.agencia = 863;
            conta.numero = 863452;
            conta.saldo = 500;

            //Console.WriteLine(nathalia.nome);
            Console.WriteLine(conta.titular.nome);

            conta.titular.nome = "Nathalia Dantas Viana";
            //Console.WriteLine(nathalia.nome);
            Console.WriteLine(conta.titular.nome);

            Console.ReadLine();
        }
    }
}
