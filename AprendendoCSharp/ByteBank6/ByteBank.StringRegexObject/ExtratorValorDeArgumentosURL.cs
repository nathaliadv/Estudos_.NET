using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.StringRegexObject
{
    public class ExtratorValorDeArgumentosURL
    {
        private readonly string _argumentos;
        public string URL { get; }
        public ExtratorValorDeArgumentosURL(string url)
        { 
            if(String.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento url não pode ser nulo ou vazio.", nameof(url));
            }
            //if(url == null )
            //{
            //    throw new ArgumentNullException(nameof(url));
            //}
            //if(url == "")
            //{
            //    throw new ArgumentException("O argumento url não pode ser uma string vazia.", nameof(url));
            //}

            int indexInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(indexInterrogacao + 1);

            URL = url;
        }

        public string GetValor(string nomeParametro)
        {
            string argumentoFormatado = _argumentos.ToLower();
            nomeParametro = nomeParametro.ToLower();

            string termo = nomeParametro + "=";

            int indexValor = argumentoFormatado.IndexOf(termo) + termo.Length;
            string resultado = argumentoFormatado.Substring(indexValor);

            int indexEComercial = resultado.IndexOf('&');

            if (indexEComercial == -1) //-1 significa que o caractere & não foi encontrado na string
            {
                return resultado;
            }
             
            return resultado.Remove(indexEComercial);
        }

    }
}
