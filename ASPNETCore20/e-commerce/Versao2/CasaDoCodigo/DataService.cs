using CasaDoCodigo_v2.Models;
using CasaDoCodigo_v2.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo_v2
{
    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IProdutoRepository produtoRepository;

        //Coloca a criação do contexto como obrigatório na criação do objeto DataService. E ai, já teremos a instancia do contexto.
        public DataService(ApplicationContext contexto, IProdutoRepository produtoRepository)
        {
            this.contexto = contexto;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            contexto.Database.EnsureCreated();

            List<Livro> livros = GetLivros();

            produtoRepository.SaveProdutos(livros);

        }

        private static List<Livro> GetLivros()
        {
            var json = File.ReadAllText("livros.json");
            //Converter o json em uma lista de objetos que serão utilizados para alimentar o BD usando a biblioteca Newtonsoft. Para isso,chama-se a classe desta biblioteca e o método para desserializar e transformar o texto em objetos, passando o tipo para o qual queremos converter como parâmetros.
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }

}
