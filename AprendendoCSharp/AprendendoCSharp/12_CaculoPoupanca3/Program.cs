using System;

namespace _12_CaculoPoupanca3
{
    class Program
    {
        static void Main(string[] args)
        {
            double valorInvestido = 1000.0;
            double fatorRendimento = 1.0036;

            for (int ano = 1; ano <= 5; ano++)
            {
                for (int mes = 1; mes <= 12; mes++)
                {
                    valorInvestido *= fatorRendimento;
                }

                fatorRendimento += 0.0010;

                Console.WriteLine($"Ao final de {ano} o valor será de {valorInvestido}");
            }

            Console.WriteLine($"Ao término do investimento o valor será de {valorInvestido}");
        }
    }
}
