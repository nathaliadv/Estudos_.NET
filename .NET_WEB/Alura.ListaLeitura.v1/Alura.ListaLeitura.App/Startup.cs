using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {   
        //É nesse método que configuramos todos os serviços necessários para uma aplicação rodar.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(); //adiciona o serviço de roteamento padrão do Asp.Net na aplicação.
        }

        //O fluxo requisição-resposta dentro do servidor é chamado Request Pipeline e é configurado aqui no método
        //Configure(). A configuração deste fluxo de requisição resposta também fica em um tipo do ASP.Net core que 
        //é o IApplicationBuilder. O código que escrevemos nesse pipeline é chamado de Middleware.
        public void Configure(IApplicationBuilder app)
        {
            //Para o .Net Core cada requisição deve ser encapsulada numa rota. Para montar as rotas precisamos de
            //um contrutor de rotas, um RouterBuilder(), que recebe como argumento a app que está sendo configurada.
            //E depois criar uma rota para cada tipo de requisição usando o MapRoute() do builder.
            //Para finalizar, cria-se a coleção de rotas usando o builder através do Build().
            var builder = new RouteBuilder(app);

            //Segundo argumento é um Delegate, são referencias aos métodos. Guarda métodos que tem retorno do mesmo tipo
            //e tipos e quantidades de argumentos iguais.
            //RequestDelegate é uma função que pode processar uma solicitação HTTP.
            builder.MapRoute("Livros/ParaLer", LivrosParaLer);
            builder.MapRoute("Livros/Lendo", LivrosLendo);
            builder.MapRoute("Livros/Lidos", LivrosLido);
            builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", NovoLivroParaLer);
            //Nessa rota é colocada uma restrição, chamada Route Constraints. Ela limita o mapeamento e faz com o 
            //Asp.Net só execute determinado request delegate se a restrição for atendida. Sem especificar daria um
            //erro 500 (problema ao tentar converter o id para int. Erro interno do servidor), se fosse passado um valor
            //diferente de int na URL. Criando a restrição, se passamos algo diferente de int, agora retorna um erro 404 
            //(o método não é executado. Página não encontrada).
            builder.MapRoute("Livros/Detalhes/{id:int}", ExibirDetalhes);
            builder.MapRoute("Cadastro/NovoLivro", ExibeFormulario);
            builder.MapRoute("Cadastro/Incluir", ProcessaFormulario);
            var rotas = builder.Build();

            app.UseRouter(rotas); //esse código determina que o estágio terminal do request pipeline irá tratar
            //as rotas definidas pela coleção armazenada na variável rotas. 


            //Para qualquer requisição que chegar o método Run() irá rodar o que for passado como argumento.
            //Esse método recebe um argumento de um tipo específico chamado de RequestDelegate. 
            //app.Run(Roteamento);
        }


        //Task é um tipo de retorno para métodos assincronos que executa uma operação, mas não retorna nenhum valor.
        //Toda informação referentes a requisição específica fica armazenado em objetos do tipo HttpContext.
        //A classe HttpContext permite acessar informações sobre o request, o response, informações sobre autenticação
        //e outras informações da requisição atual.


        //Forma "rudimentar" de fazer o roteamento. Acima usa-se o serviço do .Net Core de roteamento como forma
        //altenativa
        public Task Roteamento(HttpContext context)
        {
            var caminhosAtendidos = new Dictionary<string, RequestDelegate>
            {
                //segundo argumento são referencias aos métodos abaixo
                {"/Livros/ParaLer", LivrosParaLer},
                {"/Livros/Lendo", LivrosLendo},
                {"/Livros/Lidos", LivrosLido}
            };

            //Path é o endereço cortando toda a parte de dominio(protocolo, servidor, porta)
            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                var metodo = caminhosAtendidos[context.Request.Path]; //recebe o método de acordo com a Key
                return metodo.Invoke(context); //Invoca o método quando ocorre uma requisição para a página(context)
                //É passado context pq o Invoke() executa um método e esse método
                //é do tipo Task e precisa receber um argumento do tipo HttpContext.
            }

            context.Response.StatusCode = 404; //Recurso não encontrado pelo servidor
            return context.Response.WriteAsync("Caminho inexistente.");
        }
        public Task LivrosParaLer(HttpContext context)
        {
            //E para escrever uma resposta para a requisição que chegar ao servidor, usamos o método WriteAsync() 
            //na propriedade Response.

            var _repo = new LivroRepositorioCSV();
            var listaDeLivrosParaLer = _repo.ParaLer.Livros;
            var conteudoArquivo = CarregaArquivoHTML("para-ler");

            foreach (var livro in listaDeLivrosParaLer)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NovoItem", $"<li>{livro.Titulo} - {livro.Autor}</li>#NovoItem");
            }

            conteudoArquivo = conteudoArquivo.Replace("#NovoItem", "");

            return context.Response.WriteAsync(conteudoArquivo);
        }

        public Task LivrosLendo(HttpContext context)
        {

            var _repo = new LivroRepositorioCSV();

            return context.Response.WriteAsync(_repo.Lendo.ToString());
        }

        public Task LivrosLido(HttpContext context)
        {

            var _repo = new LivroRepositorioCSV();

            return context.Response.WriteAsync(_repo.Lidos.ToString());
        }

        public Task NovoLivroParaLer(HttpContext context)
        {
            var livro = new Livro()
            {   //Como dito antes, toda informação necessária se encontra no HttpContext. Nela é possível encontrar
                //o método GetRouteValue(), no qual o argumento chave é justamente o nome do segmento que definiu-se
                //como template da rota. Esse método retorna um object, então converte-se para string.
                Titulo = context.GetRouteValue("nome").ToString(),
                Autor = context.GetRouteValue("autor").ToString()
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return context.Response.WriteAsync("O livro foi adicionado com sucesso!");
        }

        private Task ExibirDetalhes(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);

            return context.Response.WriteAsync(livro.Detalhes());
        }
        private Task ExibeFormulario(HttpContext context)
        {
            var html = CarregaArquivoHTML("formulario");

            return context.Response.WriteAsync(html);
        }

        private string CarregaArquivoHTML(string nomeArquivo)
        {
            var nomeCompletoArquivo = $"HTML/{nomeArquivo}.html";
            using (var arquivo = File.OpenText(nomeCompletoArquivo))
            {
                return arquivo.ReadToEnd();
            }
        }

        private Task ProcessaFormulario(HttpContext context)
        {
            var livro = new Livro()
            {   //Enviando pelo POST o endereço não possui mais a query string(Query).
                //Titulo = context.Request.Query["titulo"],
                //Autor = context.Request.Query["autor"]
                //Form pega o corpo do formulário
                Titulo = context.Request.Form["titulo"], 
                Autor = context.Request.Form["autor"]
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return context.Response.WriteAsync("O livro foi adicionado com sucesso!");
        }

    }
}