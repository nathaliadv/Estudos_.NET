using System;

namespace _04_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaNath = new ContaCorrente();
            contaNath.titular = "Nathalia";
            Console.WriteLine(contaNath.saldo);

            contaNath.Depositar(200);
            Console.WriteLine(contaNath.saldo);


            bool resultadoSaque = contaNath.Sacar(50);
            Console.WriteLine(resultadoSaque);

            Console.WriteLine(contaNath.saldo);

            ContaCorrente contaMaria = new ContaCorrente();
            contaMaria.titular = "Maria";
            Console.WriteLine(contaMaria.saldo);

            bool resultadoTranferencia = contaNath.Tranferir(100, contaMaria);
            Console.WriteLine(resultadoTranferencia);
            Console.WriteLine($"Saldo atual {contaMaria.titular} é: {contaMaria.saldo}");
            Console.WriteLine($"Saldo atual {contaNath.titular} é: {contaNath.saldo}");



            Console.ReadLine();
        }
    }
}
