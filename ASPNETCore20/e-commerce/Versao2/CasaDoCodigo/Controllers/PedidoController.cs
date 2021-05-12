using CasaDoCodigo_v2.Models;
using CasaDoCodigo_v2.Models.ViewModels;
using CasaDoCodigo_v2.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo_v2.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IItemPedidoRepository itemPedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository, IItemPedidoRepository itemPedidoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
            this.itemPedidoRepository = itemPedidoRepository;
        }

        public IActionResult Carrossel()
        {
            var produtos = produtoRepository.GetProdutos();
            return View(produtos);
        }

        public IActionResult Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo)) //se não for null or vazio
            {
                pedidoRepository.AddItem(codigo);
            }

            List<ItemPedido> itens = pedidoRepository.GetPedido().Itens;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
            return View(carrinhoViewModel);
        }

        public IActionResult Cadastro()
        {
            var pedido = pedidoRepository.GetPedido();

            if(pedido == null)
            {
                return RedirectToAction("Carrossel");
            }

            return View(pedido.Cadastro);
            
        }

        [HttpPost] //isso irá restringir o acesso a action por uma chamada direta no browser(pedido/resumo), mas isso não é suficiente, pois podemos sofrer um ataque conhecido como Cros-site request forgery CSRF. Quando recebemos uma requisição proveniente de fora do nosso site, existe a possibilidade de que se trate de um agente malicioso, com interesse no furto de dados ou algo do tipo.

        //Na tela de cadastro, no final do formulario há um campo oculto(hidden). E nele há uma informação criptografada, conhecida como token de verificação. Essa informação precisa ser validada pelo servidror, caso contrário podemos sofrer um ataque externo.
        //O atributo abaixo ValidateAntiForgeryToken valida o token no momento que recebemos uma requisição.
        [ValidateAntiForgeryToken]
        public IActionResult Resumo(Cadastro cadastro)
        {
            //Validação do lado do servidor. Para ter certeza que o modelo foi preenchido corretamente e que as regras de negócio presentes são válidas, devemos verificar o estado do modelo.
            //Se o modelo não for valido, retornaremos o usuario para a view de cadastro aé que as informações tenham sido preenchidas corretamente.
            if (ModelState.IsValid)
            {
                return View(pedidoRepository.UpdateCadastro(cadastro));
            }
            return RedirectToAction("Cadastro");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public UpdateQuantidadeResponse UpdateQuantidade([FromBody]ItemPedido itemPedido)
        //FromBody- indicar que vem do corpo da requisição. Ele faz o binding dos dados da requisição com a entidade do modelo (ItemPedido).
        {
            return pedidoRepository.UpdateQuantidade(itemPedido);
        }
    }
}
