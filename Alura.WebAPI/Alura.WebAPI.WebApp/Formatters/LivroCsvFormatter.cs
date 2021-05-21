using Alura.ListaLeitura.Modelos;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Alura.WebAPI.WebApp.Formatters
{
    public class LivroCsvFormatter : TextOutputFormatter
    {
        public LivroCsvFormatter()
        {
            //Classe usada para indicar o valor do cabeçalho para media type. Irá passear a partir do texto: text/csv e application/csv
            var textCsvMediaType = MediaTypeHeaderValue.Parse("text/csv");
            var appCsvMediaType = MediaTypeHeaderValue.Parse("application/csv");
            SupportedMediaTypes.Add(textCsvMediaType);
            SupportedMediaTypes.Add(appCsvMediaType);
            SupportedEncodings.Add(Encoding.UTF8);
        }

        //Nesse método que retorna um booleano só irá chamar o Método WriteResponseBody se a condição que está nele for aceita. Se tentar formatar uma outra requisição em CSV, que não seja aceita aqui, a resposta será no formato padrão Json. (O servidor não aceita a negociação).
        protected override bool CanWriteType(Type type)
        {
            return type == typeof(LivroApi);
        }

        //implementa esse método que vem da classe abstrata TextOutputFormatter
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var livroEmCsv = "";

            //A instancia do livro está gravada em uma propriedade, um tipo object no argumento de entrada, chamada Context
            if(context.Object is LivroApi)
            {
                var livro = context.Object as LivroApi; //Converter em para livroApi

                livroEmCsv = $"{livro.Titulo};{livro.Subtitulo};{livro.Autor};{livro.Lista}";
            }

            //criar uma variavel que escreve em Streams. Ela é criada usando uma instância de WriteFactory que escreverá na stream (fluxo de bits) especifica do corpo da resposta.
            using (var escritor = context.WriterFactory(context.HttpContext.Response.Body, selectedEncoding))
            {
                return escritor.WriteAsync(livroEmCsv);
            }//escritor.Close();

        }
    }
}
