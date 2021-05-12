using CasaDoCodigo_v2.Models;
using System.Collections.Generic;

namespace CasaDoCodigo_v2.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro> livros);
        IList<Produto> GetProdutos();
    }
}