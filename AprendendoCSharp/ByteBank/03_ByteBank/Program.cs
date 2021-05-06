using System;

namespace _03_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaDaNath = new ContaCorrente();
            contaDaNath.titular = "Nathalia";
            contaDaNath.agencia = 863;
            contaDaNath.numero = 863452;
            Console.WriteLine(contaDaNath.saldo);

            ContaCorrente contaDaNathalia = new ContaCorrente();
            contaDaNathalia.titular = "Nathalia";
            contaDaNathalia.agencia = 863;
            contaDaNathalia.numero = 863452;
            Console.WriteLine(contaDaNathalia.saldo);


            Console.WriteLine(contaDaNath == contaDaNathalia);
            //Acima irá retornar false por se tratar de uma variável de referência. 
            //Quando temos uma classe de tipo complexo, com diversos campos, não guardamos o valor inteiro dele em uma variável.
            //Guardamos em algum lugar da memória do computador e apontamos o local desse objeto.


            contaDaNath = contaDaNathalia; //Aqui a contaNath passa a fazer referencia ao mesmo endereço da contaNathalia
            Console.WriteLine(contaDaNath == contaDaNathalia);

            contaDaNath.saldo = 300; //Logo, como está no mesmo endereço da Nathalia, quando mudo o saldo para Nath, muda o da Nathalia
            Console.WriteLine(contaDaNath.saldo);
            Console.WriteLine(contaDaNathalia.saldo);


            Console.ReadLine();
        }
    }
}
