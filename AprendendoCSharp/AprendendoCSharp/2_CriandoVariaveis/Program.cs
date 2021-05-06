using System;

namespace _2_CriandoVariaveis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 2 - Criando variáveis");

            int idade;

            idade = 27;

            Console.WriteLine(idade);

            idade = 10;

            Console.WriteLine(idade);

            idade = 2021 - 1993;

            Console.WriteLine("Sua idade é " + idade);
            Console.WriteLine($"Sua idade é {idade}");

            Console.WriteLine("Execução finalizada! Aperte a tecla ENTER para sair.");

            Console.ReadLine();
        }
    }
}
