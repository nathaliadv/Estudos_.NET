using System;

namespace _6_AtribuicoesDeVariaveis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando o projeto 6 - Atribuições de Variáveis");

            int idade = 32;
            int idadeGustavo = idade;

            Console.WriteLine(idade);
            Console.WriteLine(idadeGustavo);

            idade = 20;
            Console.WriteLine(idade);

            Console.ReadLine();
        }
    }
}
