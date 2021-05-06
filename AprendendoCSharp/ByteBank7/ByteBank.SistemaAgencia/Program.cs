using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using System;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Lista<int> idades = new Lista<int>();

            idades.Adicionar(item: 23);
            idades.AdicionarVarios(20, 22, 25);

            int idadeSoma = 0;
            for (int i = 0; i < idades.Tamanho; i++)
            {
                idadeSoma += idades[i];
                int idadeAtual = idades[i];
                Console.WriteLine(idadeAtual);
            }

            Console.WriteLine("Soma idades " + idadeSoma);


            Console.WriteLine($"Soma dos números = {somarVarios(1, 2, 3, 4)}");

            Console.ReadLine();
        }

        static int somarVarios(params int[] numeros)
        {
            int acumulador = 0;
            foreach (int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
        }

        static void TestaListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();
            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(15);
            listaDeIdades.Adicionar(1);
            listaDeIdades.AdicionarVarios(13, 14, 16);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idadeAtual = (int)listaDeIdades[i];
                Console.WriteLine(idadeAtual);
            }
        }
        static void TestaListaDeContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente contaGui = new ContaCorrente(111, 1111111);

            lista.AdicionarVarios(
                contaGui,
                new ContaCorrente(873, 5678792),
                new ContaCorrente(821, 5678547),
                new ContaCorrente(784, 5875887)
            );

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = {itemAtual}");
            }
        }

        static void TestaArrayInt()
        {
            //Array de inteiros, com 5 posições;
            int[] idades = new int[5];

            idades[0] = 15;
            idades[1] = 15;
            idades[2] = 18;
            idades[3] = 16;
            idades[4] = 12;

            int acumulador = 0;

            for (int indice = 0; indice < idades.Length; indice++)
            {
                Console.WriteLine($"idade no indice {indice} é {idades[indice]}");
                acumulador += idades[indice];
            }

            Console.WriteLine($"Acumulador é igual a: {acumulador}");
            Console.WriteLine("A média de idade é igual a: " + acumulador / idades.Length);

            //Console.WriteLine(idades[4]);

            //int idade = idades[4];
            //Console.WriteLine(idade);

            //int[] outroArray = idades;
            //Console.WriteLine(outroArray[4]);

            //idades[4] = 50;
            //Console.WriteLine(idades[4]);
            //Console.WriteLine(idade);
            //Console.WriteLine(outroArray[4]);

            Console.ReadLine();
        }

        static void TestaArrayDeContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
           {
                new ContaCorrente(873, 5678792),
                new ContaCorrente(763, 5672493),
                new ContaCorrente(833, 7478472)
           };

            //ContaCorrente[] contas = new ContaCorrente[3];

            //contas[0] = new ContaCorrente(873, 5678792);
            //contas[1] = new ContaCorrente(763, 5672493);
            //contas[2] = new ContaCorrente(833, 7478472);

            for (int i = 0; i < contas.Length; i++)
            {
                Console.WriteLine($"Número da conta corrente {i} é {contas[i].Numero}");
            }

            Console.ReadLine();
        }
    }

}
