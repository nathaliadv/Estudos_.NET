﻿using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
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
            Pedido pedido = pedidoRepository.GetPedido();
            return View(pedido.Itens);
        }

        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult Resumo()
        {
            Pedido pedido = pedidoRepository.GetPedido();
            return View(pedido);
        }
    }
}
