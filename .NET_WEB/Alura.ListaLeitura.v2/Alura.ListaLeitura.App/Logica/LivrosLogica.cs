using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosLogica
    {
        public static Task Detalhes(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);

            return context.Response.WriteAsync(livro.Detalhes());
        }

        public static string CarregaLista(IEnumerable<Livro> livros)
        {
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("lista");

            foreach (var livro in livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NovoItem", $"<li>{livro.Titulo} - {livro.Autor}</li>#NovoItem");
            }

            return conteudoArquivo = conteudoArquivo.Replace("#NovoItem", "");
        }
        public static Task ParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var listaDeLivrosParaLer = _repo.ParaLer.Livros;
            var html = CarregaLista(listaDeLivrosParaLer);

            return context.Response.WriteAsync(html);
        }

        public static Task Lendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var listaDeLivrosLendo = _repo.Lendo.Livros;
            var html = CarregaLista(listaDeLivrosLendo);

            return context.Response.WriteAsync(html);
        }

        public static Task Lidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var listaDeLivrosLidos = _repo.Lidos.Livros;
            var html = CarregaLista(listaDeLivrosLidos);

            return context.Response.WriteAsync(html);
        }

        public static Task Teste(HttpContext context)
        {
            return context.Response.WriteAsync("A nova funcionalidade de roteamento foi implementada");
        }
    }
}
