using CasaDoCodigo_v2.Models;
using CasaDoCodigo_v2.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo_v2.Repositories
{
    public interface IPedidoRepository
    {
        Pedido GetPedido();
        void AddItem(string codigo);
        UpdateQuantidadeResponse UpdateQuantidade(ItemPedido itemPedido);
        Pedido UpdateCadastro(Cadastro cadastro);
    }
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        //O HttpContext não está disponível automaticamente em todos os lugares do código. No Controller ele está disponível, pois todo conttrolador herda da classe Controller, que herda da classe BaseController, que fornece a instancia de HttpContext no controlador. 
        //Se estiver em um Middleware, ele é passado como um parâmetro.
        //Agora se precisar acessar os recursos do HttpContext em um serviço ou na sua camada de domínio, será necessário fazer a injeção da dependência. Foi adicionado esse serviço em ConfigureService() e injetado no construtor da classe que fará uso.

        private readonly IHttpContextAccessor contextAccessor; //fornece acesso ao HttpContext. Este encapsula todas as informações específicas de HTTP sobre uma solicitação HTTP individual.
        private readonly IItemPedidoRepository itemPedidoRepository;
        private readonly ICadastroRepository cadastroRepository;

        public PedidoRepository(ApplicationContext contexto, 
            IHttpContextAccessor contextAccessor,
            IItemPedidoRepository itemPedidoRepository,
            ICadastroRepository cadastroRepository) : base(contexto)
        {
            this.contextAccessor = contextAccessor;
            this.itemPedidoRepository = itemPedidoRepository;
            this.cadastroRepository = cadastroRepository;
        }

        public void AddItem(string codigo)
        {
            var produto = contexto.Set<Produto>()
                .Where(p => p.Codigo == codigo)
                .SingleOrDefault();

            if(produto == null)
            {
                throw new AggregateException("Produto não encontrado");
            }

            var pedido = GetPedido();

            var itemPedido = contexto.Set<ItemPedido>()
                .Where(i => i.Produto.Codigo == codigo && i.Pedido.Id == pedido.Id)
                .SingleOrDefault();

            if(itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                contexto.Set<ItemPedido>().Add(itemPedido);
                contexto.SaveChanges();
            }
        }

        public Pedido GetPedido() //Consulta que obtem o pedido para ser exibido no carrinho
        {
            var pedidoId = GetPedidoId();
            //Consultar nossa tabela de Pedido para saber se esse pedidoId existe lá. Se não existir iremos criar um novo pedido e retorná-lo aqui.
            var pedido = dbSet
                .Include(p => p.Itens)//Alem de fazer a consulta so pedido, é necessário incluir a entidade que faz parte do pedido, a entidade ItemPedido. Seria como fazer um join no SQL. 
                    .ThenInclude(i => i.Produto)
                .Include(p => p.Cadastro)
                .Where(p => p.Id == pedidoId) //Faz o join acima onde o código do pedido for igual ao pedidoId (ou seja, todos os itens que fazem parte do mesmo pedido.
                .SingleOrDefault();//SingleorDefault irá retornar o elemento se ele existir, senão, retornará um null, sem dar um erro.
            if(pedido == null)
            {
                pedido = new Pedido();
                dbSet.Add(pedido);
                contexto.SaveChanges(); //grava no banco de dados
                SetPedidoId(pedido.Id); //grava na sessão
            }
            return pedido;
        }

        private int? GetPedidoId()
        {
            //O HttpContext carrega um id de sessão. Esse id é setado com o mesmo id do pedido, no caso desta aplicação.
            return contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        //Método para gravar o pedidoId na sessão.
        private void SetPedidoId(int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }

        public UpdateQuantidadeResponse UpdateQuantidade(ItemPedido itemPedido)
        {
            var itemPedidoDB = itemPedidoRepository.GetItemPedido(itemPedido.Id);

            if (itemPedidoDB != null) //se for diferente de null quero atualizar os dados
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);
                //Modifica a quantidade do item, e o Entity Framework vai identificar essa alteração.
                //Em seguida será gravada no banco de dados pelo metodo SaveChanges()

                if(itemPedido.Quantidade == 0)
                {
                    itemPedidoRepository.RemoveItemPedido(itemPedido.Id);
                }

                contexto.SaveChanges();

                var carrinhoViewModel = new CarrinhoViewModel(GetPedido().Itens);

                return new UpdateQuantidadeResponse(itemPedidoDB, carrinhoViewModel);
            }

            throw new ArgumentException("ItemPedido não encontrado");
        }

        public Pedido UpdateCadastro(Cadastro cadastro)
        {
            var pedido = GetPedido();
            cadastroRepository.Update(pedido.Cadastro.Id, cadastro);
            return pedido;
        }
    }
}
