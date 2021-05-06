using System;

namespace _4_ConversaoEOutrosTiposNumericos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando o projeto 4");

            double salario = 1200.50;

            int salarioInteiro = (int)salario; //casting é o nome dado para essa conversão (para atribui um double a uma variável int). Quando atribui um inteiro a uma variável double o casting é implícito. 
            Console.WriteLine(salarioInteiro);

            //inteiro só suporta números entre -2 elevado a 31 e 2 elevado a 31 (32 bits)
            //Usar long para números maiores que isso  (64 bits)
            //Para um número menor, que tenha ate 16 bits, pode ser usado o short

            long valor = 13000000000;
            Console.WriteLine(valor);

            short numero = 1500;
            Console.WriteLine(numero);

            //Para usar o float é necessário colocar o f após o valor digitado.
            //Float tem uma precisão muito curta em relação a números que suporta após a casa decimal
            float altura = 1.68f;
            Console.WriteLine(altura);

            Console.ReadLine();
        }
    }
}
