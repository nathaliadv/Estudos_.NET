using System;

namespace _06_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "Nathalia";
            cliente.CPF = "12345678910";
            cliente.Profissao = "Dev";

            ContaCorrente conta = new ContaCorrente();

            conta.Titular = cliente;
            Console.WriteLine(conta.Titular.Nome);
            Console.WriteLine(conta.Titular.CPF); //Quando tem menos de 11 digitos retorna vazio


            Console.WriteLine(conta.Saldo);

            conta.Saldo = 500;
            Console.WriteLine(conta.Saldo);


            Console.ReadLine();
        }
    }
}
