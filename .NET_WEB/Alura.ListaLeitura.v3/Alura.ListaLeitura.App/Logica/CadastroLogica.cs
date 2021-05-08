using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController
    {

        public string Incluir(Livro livro)
        {
            //Aqui seria necessário converter valores que estão chegando pelo formulário para uma instancia de livro
            //Precisamos só declarar livro como um argumento de entrada. E o AspNet consiguirá converter os dados
            //de entrada do formulário em um objeto do tipo livro.
            //var livro = new Livro()
            //{
            //    Titulo = context.Request.Form["titulo"],
            //    Autor = context.Request.Form["autor"]
            //};

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return "O livro foi adicionado com sucesso";
        }

        public IActionResult ExibeFormulario()
        {
            //Depois da execução da action existe mais um estágio chamado de Execute Result. Quando retornamos uma
            //string, esse estágio entende que queremos mandar um texto puro como resposta e faz isso. 
            //Pode ser retornado vários tipos de resultado (texto puro, html, status...), então o framework encapsulou
            //o tipo de resultado de uma action em um tipo - IActionResult. 
            //Para cada tipo cria-se uma implemetação diferente. E para o caso de um resultado que retorna um HTML,
            //o tipo que implementa o IActionResult e uma resposta HTML é o ViewResult.

            //var html = HtmlUtils.CarregaArquivoHTML("formulario");
            var html = new ViewResult { ViewName = "formulario" };
            return html;
        }
    }
}
