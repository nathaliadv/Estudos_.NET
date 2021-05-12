using CasaDoCodigo_v2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//context.set<Produto> representa no contexto de Entity Framework Core a coleção de produtos do banco de dados, portanto, quando obtemos seu valor, estamos na verdade consultando todos os produtos do banco de dados.
namespace CasaDoCodigo_v2.Repositories
{//Uma classe especializada em ler, gravar, fazer alterações e manipular dados da entidade de produtos - Repositories;
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Produto> GetProdutos()
        {
            //return contexto.Set<Produto>().ToList();
            return dbSet.ToList();
        }

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {   
                //Caso o produto não exista, faremos a importação do mesmo, a partir do Dbset, naquele conjunto de entidades mantido pelo Entity Framework, equivalente a uma tabela e representado peolo contexto.Set<Produto>, no qual colocaremos dentro da condição if.
                if(!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    //Aqui ainda está adicionando informações em memória
                    //contexto.Set<Produto>().Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }
            }
            //Para que o envio das informações para o BD seja feito só uma vez, quando tivermos todos os produtos carregados em memória, prontos para serem adicionados ao BD, faz-se esse armazenamento apenas depois de finalizado o laço.
            contexto.SaveChanges();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
