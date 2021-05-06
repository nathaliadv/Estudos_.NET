using System;

namespace _11_CalculaPopanca2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando o projeto 11");

            double valorInvestido = 1000.0;
            double rendimento = 0.0036;

            for (int mes = 1; mes <= 12; mes++)
            {
                valorInvestido *= (1 + rendimento);
                Console.WriteLine($"No mês {mes}, o valor será de {valorInvestido}");
            }

            Console.ReadLine();
        }
    }
}
