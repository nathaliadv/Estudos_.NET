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
        static void LidandoComFileStreamDiretamente()
        {
            var enderecoArquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024]; //array de bytes de 10224 posiçoes = 1 kb
                var numeroDeBytesLidos = -1; // Adotando o -1 pq é um valor que nunca será retornado pelo Read();
                                             //O Read() retorna a quantidade de bytes lidos. Ele continua retornado a quantidade de bytes lidos até 
                                             //não ter mais bytes a serem lidos no arquivo e ai retornará 0.
                while (numeroDeBytesLidos != 0)
                {
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024); //começa a ler e armazenar a partir da posiçao 0 do buffer e grave até o fim dele.
                    Console.WriteLine($"Número de Bytes lidos: {numeroDeBytesLidos}");

                    EscreverBuffer(buffer, numeroDeBytesLidos);

                }
            }

            //fluxoDoArquivo.Close();
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        //passar o número de bytes lidos e assim na hora de realizar o encoding e tranformar em string sabemos
        //até onde devemos avançar no buffer. Se não o buffer pode acabar guardando infos do Read() anterior
        //caso o novo não ocupe o espaço total de 1024
        {
            //var utf8 = new UTF8Encoding();
            var utf8 = Encoding.Default; //Encoding padrão do sistema operacional

            var texto = utf8.GetString(buffer, 0, bytesLidos);
            Console.Write(texto);

            //Aqui estava imprimindo cada byte
            //foreach(var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }
    }
}