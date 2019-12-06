using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Enums;
using RoleTopMVC.Models;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class PedidoController : AbstractController
    {

        PedidoRepository pedidoRepository = new PedidoRepository();
        EventoRepository eventoRepository = new EventoRepository();
        ClienteRepository clienteRepository = new ClienteRepository();
        public IActionResult Index(){

            PedidoViewModel pvm = new PedidoViewModel();
            pvm.Eventos = eventoRepository.ObterTodos();

            var usuarioLogado = ObterUsuarioSession();
            var nomeUsuarioLogado = ObterUsuarioNomeSession();
            if(!string.IsNullOrEmpty(nomeUsuarioLogado)){
                pvm.NomeUsuario = nomeUsuarioLogado;
            }

            var clienteLogado = clienteRepository.ObterPor(usuarioLogado);
            if(clienteLogado != null){
                pvm.Cliente = clienteLogado;
            }

            pvm.NomeView = "Pedido";
            pvm.UsuarioEmail = usuarioLogado;
            pvm.UsuarioNome = nomeUsuarioLogado;    

            return View(pvm);
        }

        public IActionResult Registrar(IFormCollection form){
            ViewData["Action"] = "Pedido";
            Pedido pedido = new Pedido();
            
            var nomeEvento = form["nomeEvento"];
            Evento evento = new Evento();
            evento.NomeEvento = nomeEvento;
            evento.TipoEvento = form["tipoEvento"];
            evento.Dia = DateTime.Parse(form["dia"]);
            evento.HoraFim = DateTime.Parse(form["horaFim"]);
            evento.Descricao = form["descricao"];

            pedido.Evento = evento;


            Cliente cliente = new Cliente() {
                Nome = form["nome"],
                Endereco = form["endereco"],
                Telefone = form["telefone"],
                Email = form["email"]

            };

            pedido.Cliente = cliente;

            pedido.DataDoPedido = DateTime.Now;

            if(pedidoRepository.Inserir(pedido)){
                return View("Sucesso", new RespostaViewModel(){
                    NomeView = "Pedido",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            } else {
                return View("Erro", new RespostaViewModel(){
                    NomeView = "Pedido",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }

        public IActionResult Aprovar(ulong id){
            Pedido pedido = pedidoRepository.ObterPor(id);
            pedido.Status = (uint) StatusPedido.APROVADO;

            if(pedidoRepository.Atualizar(pedido)){
                return RedirectToAction("Dashboard", "Administrador");
            } else {
                return View("Erro", new RespostaViewModel(){
                    Mensagem = "Houve um erro ao Aprovar pedido.",
                    NomeView = "Dashboard",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }

        public IActionResult Reprovar(ulong id){
            Pedido pedido = pedidoRepository.ObterPor(id);
            pedido.Status = (uint) StatusPedido.REPROVADO;

            if(pedidoRepository.Atualizar(pedido)){
                return RedirectToAction("Dashboard", "Administrador");
            } else {
                return View("Erro", new RespostaViewModel(){
                    Mensagem = "Houve um erro ao Reprovar pedido.",
                    NomeView = "Dashboard",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }
    }
}