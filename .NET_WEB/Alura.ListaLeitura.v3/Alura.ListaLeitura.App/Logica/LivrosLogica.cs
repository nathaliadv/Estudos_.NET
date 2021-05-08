using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController : Controller
    {
        //Através do roteamento padrão, um objeto dessa classe foi criado e a instância é conhecida pelo framework.
        //No estágio de execução da action, o que na verdade está sendo feito é chamar um método desse objeto.
        //então, se declararmos uma propriedade aqui nesse controller, poderiamos fazer esse objeto ter acesso a 
        //essa propriedade no estágio de execução da action.

        public IEnumerable<Livro> Livros { get; set; }

        //public static string CarregaLista(IEnumerable<Livro> livros)
        //{
        //    var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("lista");

        //    foreach (var livro in livros)
        //    {
        //        conteudoArquivo = conteudoArquivo
        //            .Replace("#NovoItem", $"<li>{livro.Titulo} - {livro.Autor}</li>#NovoItem");
        //    }

        //    return conteudoArquivo = conteudoArquivo.Replace("#NovoItem", "");
        //}

        //Aqui as actions abaixo não terão mais acesso a string retornada em CarregaLista() para fazer a substituição
        //no HTML dos livros especificos. Precisamos retornar uma página dinâmica e, para isso, o framework delegou a
        //responsabilidade a entidade específica chmada View Engine, ou seja, um motor que se encarrega de juntar o
        //HTML com o código necessário para tornar a página dinâmica, Cada view engine tem suas proprias regras e 
        //padronizações. A view engine padrão é uma implementação chamada Razor. As regras são: as views devem ter
        //extensão cshtml e pode-se escrever código C# dentro do arquivo. 
        public IActionResult ParaLer()
        {
            var _repo = new LivroRepositorioCSV();
            //var listaDeLivrosParaLer = _repo.ParaLer.Livros;
            //var html = CarregaLista(listaDeLivrosParaLer);

            //ViewBag é uma propriedade herdada da classe base Controller
            ViewBag.Livros = _repo.ParaLer.Livros;

            //return context.Response.WriteAsync(html);
            return View("lista");// Retornar uma instancia de view Result para a view lista
        }

        public IActionResult Lendo()
        {
            var _repo = new LivroRepositorioCSV();
            //var listaDeLivrosLendo = _repo.Lendo.Livros;
            //var html = CarregaLista(listaDeLivrosLendo);

            ViewBag.Livros = _repo.Lendo.Livros;

            return View("lista");
            //return context.Response.WriteAsync(html);
        }

        public IActionResult Lidos()
        {
            var _repo = new LivroRepositorioCSV();
            //var listaDeLivrosLidos = _repo.Lidos.Livros;
            //var html = CarregaLista(listaDeLivrosLidos);

            ViewBag.Livros = _repo.Lidos.Livros;

            return View("lista");
            //return context.Response.WriteAsync(html);
        }

        //Não precisa mais ter um método do tipo RequestDelegate
        //public static Task Teste(HttpContext context)
        //{
        //    return context.Response.WriteAsync("A nova funcionalidade de roteamento foi implementada");
        //}
        public string Teste()
        {
            return "Método Teste do Controller Livros, agora sem ser um RequestDelegate. " +
                "Seu retorno é apenas uma string. Usando o framework AspNet Core MVC.";
        }
        public string Detalhes(int id)
        {
            //O framework estabelece um estagio que acontece antes da execução do metodo no request pipeline chamado
            //Model Binding. Nesse estágio o MVC faz todas as conversões necessárias pro modelo que você precisa usar
            //dentro da action.
            //O estagio de Model Binding irá procurar por informações referentes a um livro em três fontes:
            //formulário, na rota e 

            //int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);

            return livro.Detalhes();
        }
     
    }
}
