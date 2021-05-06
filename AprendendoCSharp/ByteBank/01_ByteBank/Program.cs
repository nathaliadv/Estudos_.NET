using System;

namespace _01_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaNathalia = new ContaCorrente();
            contaNathalia.titular = "Nathalia";
            contaNathalia.agencia = 863;
            contaNathalia.numero = 863452;
            contaNathalia.saldo = 100;

            Console.WriteLine($"Titular: {contaNathalia.titular}");
            Console.WriteLine($"Agência: {contaNathalia.agencia}");
            Console.WriteLine($"Número da Conta: {contaNathalia.numero}");
            Console.WriteLine($"Saldo: {contaNathalia.saldo}");

            Console.ReadLine(); 
        }
    }
}
