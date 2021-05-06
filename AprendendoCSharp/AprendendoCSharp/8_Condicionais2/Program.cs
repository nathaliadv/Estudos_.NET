using System;

namespace _8_Condicionais2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando o projeto 8 - Condicionais");

            int idadeJoao = 16;
            int quantidadePessoas = 2;
            bool acompanhado = quantidadePessoas >= 2;

            if (idadeJoao >= 18 || acompanhado)
            {
                Console.WriteLine("João pode entrar!");
            }
            else
            {
                Console.WriteLine("João não pode entrar!");
            }

            Console.ReadLine();
        }
    }
}
