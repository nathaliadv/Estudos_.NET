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
        static void EscritaBinaria()
        {
            var caminhoArquivo = "contaCorrente.txt";
            using (var fs = new FileStream(caminhoArquivo, FileMode.Create))
            using (var escritor = new BinaryWriter(fs))
            {
                escritor.Write(456); //numero da agencia
                escritor.Write(5127132); //numero da conta
                escritor.Write(4000.50); //saldo da conta
                escritor.Write("Gustavo Braga");
            }
        }

        static void LeituraBinaria()
        {
            var caminhoArquivo = "contaCorrente.txt";
            using (var fs = new FileStream(caminhoArquivo, FileMode.Open))
            using (var leitor = new BinaryReader(fs))
            {
                var agencia = leitor.ReadInt32();
                var numeroConta = leitor.ReadInt32();
                var saldo = leitor.ReadDouble();
                var titular = leitor.ReadString();

                Console.WriteLine($"{agencia} | {numeroConta} | {saldo} | {titular}");
            }

        }
    }
}
