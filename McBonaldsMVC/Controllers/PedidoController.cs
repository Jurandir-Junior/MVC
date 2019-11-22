using System;
using McBonaldsMVC.Models;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMVC.Controllers {
    public class PedidoController : Controller {
        PedidoRepository pedidoRepository = new PedidoRepository ();
        HamburguerRepository hamburguerRepository = new HamburguerRepository();

        ShakesRepository shakeRepository = new ShakesRepository();

        public IActionResult Index () {

            var hamburgueres = hamburguerRepository.ObterTodos();
            var shake = shakeRepository.ObterTodos();

            PedidoViewModel pedido = new PedidoViewModel();
            
            pedido.Hamburgueres = hamburgueres;
            pedido.Shake = shake;

            

            return View (pedido);
        }

        public IActionResult Registrar (IFormCollection form) {
            ViewData["Action"] = "Pedido";
            Pedido pedido = new Pedido ();

            
            var precoShake = shakeRepository.ObterPrecoDe(form["shake"]);
            var nomeShake = form["shake"];
            Shake shake = new Shake (nomeShake,precoShake);

            pedido.Shake = shake;

            Hamburguer hamburguer = new Hamburguer (form["hamburguer"],hamburguerRepository.ObterPrecoDe(form["hamburguer"]));
            var precoHamburger = hamburguerRepository.ObterPrecoDe(form["hamburguer"]);
            pedido.Hamburguer = hamburguer;

            Cliente cliente = new Cliente () {
                Nome = form["nome"],
                Endereco = form["endereco"],
                Telefone = form["telefone"],
                Email = form["email"]
            };

            pedido.Cliente = cliente;

            pedido.DataDoPedido = DateTime.Now;

            pedido.PrecoTotal = precoHamburger + precoShake;

            if (pedidoRepository.Inserir (pedido)) {
                return View ("Sucesso");
            } else {
                return View ("Erro");
            }
        }
    }
}