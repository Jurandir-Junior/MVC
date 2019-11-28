using System;
using McBonaldsMVC.Models;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMVC.Controllers {
    public class PedidoController : AbstractController {
        PedidoRepository pedidoRepository = new PedidoRepository ();
        HamburguerRepository hamburguerRepository = new HamburguerRepository();

        ShakesRepository shakeRepository = new ShakesRepository();

        ClienteRepository clienteRepository = new ClienteRepository();

        public IActionResult Index () {

            var hamburgueres = hamburguerRepository.ObterTodos();
            var shake = shakeRepository.ObterTodos();

            PedidoViewModel pedido = new PedidoViewModel();
            
            pedido.Hamburgueres = hamburgueres;
            pedido.Shake = shake;

            var usuarioLogado = ObterUsuarioSession();
            var nomeUsuarioLogado = ObterUsuarioNomeSession();
            if(!string.IsNullOrEmpty(nomeUsuarioLogado))
            {
                pedido.NomeUsuario = nomeUsuarioLogado;
            }

            var clienteLogado = clienteRepository.ObterPor(usuarioLogado);
            if(clienteLogado != null)
            {
                pedido.Cliente = clienteLogado;
            }
            pedido.NomeView = "Pedido";
            pedido.UsuarioEmail = ObterUsuarioSession();
            pedido.UsuarioNome = ObterUsuarioNomeSession();
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
                return View ("Sucesso", new RespostaViewModel()
                {
                    Mensagem = "Aguarde a aprovação dos nossos administradores",
                    NomeView = "Sucesso",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            } else {
                return View ("Erro", new RespostaViewModel()
                {
                    Mensagem = "Houve um erro ao processar seu pedido. Tente novamente",
                    NomeView = "Erro",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }
    
        public IActionResult Aprovar(ulong id)
        {
            Pedido pedido = pedidoRepository.ObterPor(id);
        }
    }
}