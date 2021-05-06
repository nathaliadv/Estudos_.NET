using System;

namespace _7_Condicionais
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando o projeto 7 - Condicionais");

            int idadeJoao = 16;
            int quantidadePessoas = 2;

            if (idadeJoao >= 18 )
            {
                Console.WriteLine("João pode entrar! É maior de idade.");
            }
            else
            {
                if (quantidadePessoas >=2)
                {
                    Console.WriteLine("João pode entrar! É menor de idade, mas está acompanhado.");
                } 
                else
                {
                    Console.WriteLine("João não pode entrar!");
                }
            }

            Console.ReadLine();
        }
    }
}
