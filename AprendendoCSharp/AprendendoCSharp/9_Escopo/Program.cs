using System;

namespace _9_Escopo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando o projeto 9 - Escopo");

            int idade = 18;
            bool acompanhado = false;
            string mensagemAdicional;

            if (acompanhado)
            {
                mensagemAdicional = "João está acompanhado!";
            } 
            else
            {
                mensagemAdicional = "João não está acompanhado!";
            }

            if (idade >= 18 || acompanhado == true)
            {
                Console.WriteLine("João pode entrar!");
                Console.WriteLine(mensagemAdicional);
            }
            else
            {
                Console.WriteLine("João não pode entrar!");
                Console.WriteLine(mensagemAdicional);
            }

            Console.ReadLine();
        }
    }
}
