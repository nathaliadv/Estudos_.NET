using System;

namespace _13_ForEncadeado
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 13!");

            for (int contadorLinha = 1; contadorLinha < 10; contadorLinha++)
            {
                for(int contadorColuna = 1; contadorColuna < 10; contadorColuna++)
                {
                    Console.Write("*");
                    if (contadorColuna >= contadorLinha)
                        break;
                }
                Console.WriteLine();
            }


            //Outra forma

            for (int contadorLinha = 1; contadorLinha < 10; contadorLinha++)
            {
                for (int contadorColuna = 1; contadorColuna <= contadorLinha; contadorColuna++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
