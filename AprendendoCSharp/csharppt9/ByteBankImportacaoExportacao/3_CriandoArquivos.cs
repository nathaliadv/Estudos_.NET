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
        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using(var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew))
            {
                var contaComString = "123,567,9987.0,Nathalia";
                var encoding = Encoding.UTF8;

                var bytes = encoding.GetBytes(contaComString);

                fluxoDeArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        static void CriarArquivoComWriter()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using(var escritor = new StreamWriter(fluxoDeArquivo))
            {
                escritor.WriteLine("123,567,9987.0,Nathalia");
            }
        }

        static void TestaEscrita()
        {
            var caminhoArquivo = "teste.txt";

            using(var fluxoArquivo = new FileStream(caminhoArquivo, FileMode.Create))
            using(var escritor = new StreamWriter(fluxoArquivo))
            {
                for(var i = 0; i < 1000000; i++)
                {
                    escritor.WriteLine($"Linha {i}");
                    escritor.Flush(); //despeja o buffer para o Stream

                    Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter para adicionar mais uma");
                    Console.ReadLine();
                }
            }
        }
    }
}