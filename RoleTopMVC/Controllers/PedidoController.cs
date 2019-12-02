using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Models;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class PedidoController : Controller
    {

        PedidoRepository pedidoRepository = new PedidoRepository();
        EventoRepository eventoRepository = new EventoRepository();
        public IActionResult Index(){

            PedidoViewModel pvm = new PedidoViewModel();
            pvm.Eventos = eventoRepository.ObterTodos();
            return View(pvm);
        }

        public IActionResult Registrar(IFormCollection form){
            ViewData["Action"] = "Pedido";
            Pedido pedido = new Pedido();
            
            var nomeEvento = form["nome"];
            Evento evento = new Evento();
            evento.Nome = nomeEvento;
            evento.Tipo = form["tipo"];
            evento.Dia = DateTime.Parse(form["dia"]);
            evento.HoraInicio = DateTime.Parse(form["horaInicio"]);
            evento.HoraFim = DateTime.Parse(form["horaFim"]);
            evento.Descricao = form["descricao"];


            Cliente cliente = new Cliente() {
                Nome = form["nome"],
                Endereco = form["endereco"],
                Telefone = form["telefone"],
                Email = form["email"]

            };

            pedido.Cliente = cliente;

            pedido.DataDoPedido = DateTime.Now;

            if(pedidoRepository.Inserir(pedido)){
                return View("Sucesso");
            } else {
                return View("Erro");
            }
        }
    }
}