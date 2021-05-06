using System;

namespace ByteBank.StringRegexObject
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "pagina?argumentos";
            
            Console.WriteLine(url);

            //string argumentos = url.Substring(7);
            //Console.WriteLine(argumentos);

            int indiceInterrogacao = url.IndexOf('?');
            Console.WriteLine(indiceInterrogacao);

            string argumentos = url.Substring(indiceInterrogacao + 1);
            Console.WriteLine(argumentos);

            string urlParametros = "https://www.bytebank.com/cambio?valor=1500&moedaOrigem=real&moedaDestino=dolar";

            ExtratorValorDeArgumentosURL extrator = new ExtratorValorDeArgumentosURL(urlParametros);

            string valor1 = extrator.GetValor("moedaOrigem");
            Console.WriteLine("Moeda origem: " + valor1);

            string valor2 = extrator.GetValor("moedaDestino");
            Console.WriteLine("Moeda destino: " + valor2);

            string valor = extrator.GetValor("valor");
            Console.WriteLine("Valor: " + valor);

            Console.ReadLine();
        }
 
    }
}
