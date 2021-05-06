using ByteBank.Modelos;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 54637),
                null,
                null,
                new ContaCorrente(234, 44637),
                new ContaCorrente(641, 64637),
                null,
                new ContaCorrente(241, 34637)
            };

            //contas.Sort(); //CHAMA A IMPLEMENTAÇÃO DADA EM ICOMPARABLE
            //Console.WriteLine("Usando sort - Com a implementação do IComparable na classe");

            //foreach (var conta in contas)
            //{
            //    Console.WriteLine($"Número: {conta.Numero} Agência: {conta.Agencia}");
            //}

            //contas.Sort(new ComparadorContaCorrentePorAgencia());
            //Console.WriteLine("Usando a sobrecarga do sort - IComparer");

            //foreach (var conta in contas)
            //{
            //    Console.WriteLine($"Número: {conta.Numero} Agência: {conta.Agencia}");
            //}

            IOrderedEnumerable<ContaCorrente> contasOrdenada =
                contas.OrderBy(conta => {

                    if(conta == null) //Se for nulo essa conta deve ficar no final da ordenação(MaxValue)
                    {
                        return int.MaxValue;
                    };

                    return conta.Numero;
                });


            Console.WriteLine("Usando OrderBy");
            foreach (var conta in contasOrdenada)
            {
                if(conta != null)
                {
                    Console.WriteLine($"Número: {conta.Numero} Agência: {conta.Agencia}");
                }
                //As contas que forem null não serão printadas
            }


            var contasNaoNulas = contas.Where(conta => conta != null);

            IOrderedEnumerable<ContaCorrente> contasOrdenada2 =
                contasNaoNulas.OrderBy(conta => conta.Numero);

            Console.WriteLine("Fazendo o filtro das contas não nulas usando o Where");
            foreach(var conta in contasOrdenada2)
            {
                Console.WriteLine($"Número: {conta.Numero} Agência: {conta.Agencia}");
            }

            Console.ReadLine(); 
        }


        static void TestaSortEList()
        {
            var nomes = new List<string>() { "Nathalia", "Maria", "Alvaro" };

            nomes.Sort();

            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }

            var idades = new List<int>();

            idades.Add(11);
            idades.Add(16);
            idades.Add(21);
            idades.Add(13);
            idades.Add(15);
            idades.Add(22);

            //idades.AddRange(new int[] { 24, 26, 17, 24 });

            //ListExtensoes<string>.AdicionarVarios(idades, 12, 13, 19, 32, 21);

            //idades.AdicionarVarios<int>(12, 13, 18, 15); //o int pode ser apagado. Pq ele é o mesmo <T> da lista
            idades.AdicionarVarios(12, 13, 18, 15);
            idades.AdicionarVarios(1, 60);
            idades.Remove(11);

            idades.Sort();

            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }

            string nomeN = "Nathalia";

            nomeN.TesteGenerico<string>(); //string não é um metodo generico, então aqui é preciso definir o tipo <T>
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
        
        static void TesteLista()
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
