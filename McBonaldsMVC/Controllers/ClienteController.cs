using System;
using McBonaldsMVC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using McBonaldsMVC.ViewModels;
using McBonaldsMVC;

namespace McBonaldsMVC.Controllers
{
    
    public class ClienteController : Controller
    {

        private const string  SESSION_CLIENTE_EMAIL = "email_cliente";
        private ClienteRepository clienteRepository = new ClienteRepository();

        private PedidoRepository pedidoRepository = new PedidoRepository();
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            ViewData["Action"] = "Login";
            try{
            System.Console.WriteLine("=====================");
            System.Console.WriteLine(form["email"]);
            System.Console.WriteLine(form["senha"]);
            System.Console.WriteLine("=====================");

            var usuario = form["email"];
            var senha = form["senha"];

            var cliente = clienteRepository.ObterPor(usuario);

            if(cliente != null)
            {
                if(cliente.Senha.Equals(senha))
                {
                    HttpContext.Session.SetString("SESSION_CLIENTE_EMAIL", usuario);
                    HttpContext.Session.SetString("SESSION_CLIENTE_NOME", cliente.Nome);
                    return RedirectToAction("Historico", "Cliente");
                } else {
                    return View("Erro", new RespostaViewModel("Senha incorreta"));
                }
            } else {
                return View("Erro", new RespostaViewModel($"Usuário {usuario} não foi encontrado"));
            }
            

            
            } catch(Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro");
            }
        }

        public IActionResult Historico()
        {
            var emailCliente = HttpContext.Session.GetString(SESSION_CLIENTE_EMAIL);
            var pedidos = pedidoRepository.ObterTodosPorCliente(emailCliente);

            return View(new HistoricoViewModel()
            {
                Pedidos = pedidos
            });
        }
    }
}