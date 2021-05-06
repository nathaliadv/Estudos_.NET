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
        static void UsandoStreamReader()
        {
            var enderecoArquivo = "contas_csv.txt";

            using (var fluxoDeArquivo = new FileStream(enderecoArquivo, FileMode.Open)) //quando tem dois using aninhados pode ser usados dessa forma, sem as {} do using externo
            using (var leitor = new StreamReader(fluxoDeArquivo))
            {
                while (!leitor.EndOfStream) //enquanto não chegamos no final do stream
                {
                    var linha = leitor.ReadLine(); //valor da linha lida
                    //Console.WriteLine(linha);

                    var contaCorrente = ConverterStringParaContaCorrente(linha);
                    var msg = $"{contaCorrente.Titular.Nome}, N° {contaCorrente.Numero}, ag. {contaCorrente.Agencia}, saldo: R${contaCorrente.Saldo}";
                    Console.WriteLine(msg);
                }
            }

            Console.ReadLine();
        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            var campos = linha.Split(',');

            var agencia = int.Parse(campos[0]);
            var numero = int.Parse(campos[1]);
            var saldo = double.Parse(campos[2].Replace('.', ','));
            var nome = campos[3];

            var titular = new Cliente();
            titular.Nome = nome;

            var resultado = new ContaCorrente(agencia, numero);
            resultado.Depositar(saldo);
            resultado.Titular = titular;

            return resultado;
        }

    }
}