using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao 
{ 
    partial class Program 
    { 
        static void Main(string[] args) 
        {
            File.WriteAllText("escrevendoComAClassFile.txt", "Testando o WriteAllText da classe File");
            Console.WriteLine("Arquivo criado");

            var bytes = File.ReadAllBytes("contas.txt");
            Console.WriteLine($"Total de bytes do arquivo: {bytes.Length}");

            var linhas = File.ReadAllLines("contas.txt");
            Console.WriteLine(linhas.Length);

            foreach(var linha in linhas)
            {
                Console.WriteLine(linha);
            }
            Console.ReadLine();

            Console.WriteLine("Digite seu nome: ");
            var nome = Console.ReadLine();
            Console.WriteLine(nome);


            //LeituraBinaria();

            //using(var fs = new FileStream("testaTipos.txt", FileMode.Create))
            //using (var escritor = new StreamWriter(fs))
            //{
            //    escritor.WriteLine(true);
            //    escritor.WriteLine(false);
            //    escritor.WriteLine(12549985664544);
            //}

            Console.WriteLine("Aplicação finalizada...");
            Console.ReadLine();
        }

    }
} 
 