using System;

namespace _10_CalculaPoupanca
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 10");

            double valorInvestido = 1000.0;
            double rendimento = 0.0036;
            int mes = 1;

            while (mes <= 12)
            {
                valorInvestido += valorInvestido * rendimento;
                Console.WriteLine($"Após {mes} meses, terá R$ {valorInvestido}");
                mes++ ;
            }


            Console.ReadLine();
        }
    }
}
