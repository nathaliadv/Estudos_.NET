using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    class CadastroLogica
    {
        public static Task ExibeFormulario(HttpContext context)
        {
            var html = HtmlUtils.CarregaArquivoHTML("formulario");

            return context.Response.WriteAsync(html);
        }

        public static Task NovoLivro(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.GetRouteValue("nome").ToString(),
                Autor = context.GetRouteValue("autor").ToString()
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return context.Response.WriteAsync("O livro foi adicionado com sucesso!");
        }


        public static Task Incluir(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.Request.Form["titulo"],
                Autor = context.Request.Form["autor"]
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return context.Response.WriteAsync("O livro foi adicionado com sucesso!");
        }
    }
}
