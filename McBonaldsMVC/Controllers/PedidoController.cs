using System;
using McBonaldsMVC.Models;
using McBonaldsMVC.ViewModels;
using McBonaldsMVC;
using McBonaldsMVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMVC.Controllers
{
    public class PedidoController : Controller
    {
        PedidoRepository pedidoRepository = new PedidoRepository();
        HamburguerRepository hamburguerRepository = new HamburguerRepository();
        ShakesRepository shakesRepository = new ShakesRepository();


        public IActionResult Index()
        {
            var hamburgueres = hamburguerRepository.ObterTodos();
            var shakes = shakesRepository.ObterTodos();

            PedidoViewModel pedido = new PedidoViewModel();

            pedido.Hamburgueres = hamburgueres;
            pedido.Shakes = shakes;

            return View(pedido);
        }

        public IActionResult Registrar(IFormCollection form)
        {
            ViewData["Action"] = "Pedido";
            Pedido pedido = new Pedido();

            Shake shake = new Shake();
            var nomeShake = form["shake"];    
            shake.Nome = nomeShake;
            shake.Preco = shakesRepository.ObterPrecoDe(nomeShake);

            pedido.Shake = shake;

            var nomeHamburguer = form["hamburguer"];
            Hamburguer hamburguer = new Hamburguer(nomeHamburguer, hamburguerRepository.ObterPrecoDe(nomeHamburguer));
            
            pedido.Hamburguer = hamburguer;

            Cliente cliente = new Cliente()
            {
                Nome = form["nome"],
                Endereco = form["endereco"],
                Telefone = form["telefone"],
                Email = form["email"]
            };

            pedido.Cliente = cliente;

            pedido.DataDoPedido = DateTime.Now;

            pedido.PrecoTotal = hamburguer.Preco + shake.Preco;

            pedidoRepository.Inserir(pedido);

            return View("Sucesso");
        }
    }
}