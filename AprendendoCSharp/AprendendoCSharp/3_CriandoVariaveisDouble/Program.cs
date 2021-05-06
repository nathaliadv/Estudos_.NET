using System;

namespace _3_CriandoVariaveisDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 3 - Criando Variáveis Double");

            double salario;
            salario = 3500.00;

            Console.WriteLine($"Salário de {salario}");

            double valor;
            valor = 15.0 / 2;

            Console.WriteLine(valor);

            Console.WriteLine("Execução finalizada! Aperte a tecla ENTER para encerrar.");

            Console.ReadLine();
        }
    }
}
