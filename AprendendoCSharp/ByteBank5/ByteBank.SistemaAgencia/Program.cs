using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using System;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(243, 271762);

            Console.WriteLine(conta);
            Console.WriteLine(conta.ToString());

            Cliente carlos_1 = new Cliente();
            carlos_1.Nome = "Carlos";
            carlos_1.CPF = "234.124.123-21";
            carlos_1.Profissao = "Designer";

            Cliente carlos_2 = new Cliente();
            carlos_2.Nome = "Carlos";
            carlos_2.CPF = "234.124.123-21";
            carlos_2.Profissao = "Designer";

            if (carlos_1.Equals(carlos_2))
            {
                Console.WriteLine("São iguais");
            }
            else
            {
                Console.WriteLine("Não são iguais");
            }


            Console.ReadLine();
        }
    }
}
