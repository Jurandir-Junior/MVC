using System;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMVC.Controllers
{
    public class ClienteController : AbstractController
    {
        private ClienteRepository clienteRepository = new ClienteRepository();

        private PedidoRepository pedidoRepository = new PedidoRepository();

        [HttpGet]
        public IActionResult Login()
        {
            return View(new BaseViewModel
            {
                NomeView = "Login",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            ViewData["Action"] = "Login";
            try
            {
                System.Console.WriteLine("=========aaaa=========");
                System.Console.WriteLine(form["email"]);
                System.Console.WriteLine(form["senha"]);
                System.Console.WriteLine("===========bbbb=======");

                var usuario = form["email"];
                var senha = form["senha"];

                var cliente = clienteRepository.ObterPor(usuario);
                
                if (cliente != null)
                {
                    if(cliente.Senha.Equals(senha))
                    {
                        HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario); // HttpContext.Session == nela você guarda as coisas q ficarão visiveis aos outros controllers
                        HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                        return RedirectToAction("Historico","Cliente");  //RedirectToAction chama outro método, no caso Historico q está dentro do controller Cliente mesmo;
                    }
                    else{
                        return View("Erro",new RespostaViewModel("Senha incorreta"));
                    }
                }
                else
                {
                                                                //abaixo entre as () está sendo enviada a mensagem para a variavel "mensagem" do RespostaViewModel
                    return View("Erro", new RespostaViewModel($"Usuário {usuario} não foi encontrado")); //mostrar q o usuario está errado 
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro");
            }
        }
        public ActionResult Historico()
        {
            var emailCliente = ObterUsuarioSession();

            var pedidos = pedidoRepository.ObterTodosPorCliente(emailCliente);
            
            return View(new HistoricoViewModel() {
                Pedidos = pedidos,
                NomeView = "Histórico",
                UsuarioNome = ObterUsuarioNomeSession(),
                UsuarioEmail = ObterUsuarioSession()
            });
        }
        public IActionResult Logoff()
    {
        HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);
        HttpContext.Session.Remove(SESSION_CLIENTE_NOME);
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
    }    
}