using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo_v2.Models.ViewModels
{
    //O ideal é que as regras de negócio não fiquem diretamente na view. Então cria-se a ViewModel para que está seja uma classe que fornecerá dados para a view. A vantagem da view model é que ela não precisa ser associada ao Entity Framework, pois diferente das classes do modelo, não será gravada no banco de dados como tabela. 
    public class CarrinhoViewModel
    {
        public IList<ItemPedido> Itens { get; }

        public CarrinhoViewModel(IList<ItemPedido> itens)
        {
            Itens = itens;
        }

        public decimal Total => Itens.Sum(i => i.Quantidade * i.PrecoUnitario);
    }
}
