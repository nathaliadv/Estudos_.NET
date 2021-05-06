using System;

namespace _5_CaracteresETextos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando o projeto 5 - Caracteres e textos");

            //Aspas duplas é usada para texto. Aspas simples para um caracter.
            char primeiraLetra = 'a';
            Console.WriteLine(primeiraLetra);

            primeiraLetra = (char)65; //casting
            Console.WriteLine(primeiraLetra); //retorna um A

            primeiraLetra = (char)(primeiraLetra + 1);
            Console.WriteLine(primeiraLetra);//retorna um B

            //Isso corresponde a tabela ASCII

            string titulo = "Alura cursos de tecnologia " + 2021;
            Console.WriteLine(titulo);

            string cursos = @"- .NET
- Java
- JavaScript";
            Console.WriteLine(cursos);


            Console.ReadLine();
        }
    }
}
