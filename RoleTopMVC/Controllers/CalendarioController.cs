using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class CalendarioController : AbstractController
    {
        PedidoRepository pedidoRepository = new PedidoRepository();

        public IActionResult Index(){
            
            var pedidosAceitos = pedidoRepository.ObterAprovados();    

            return View(new CalendarioViewModel(){
                PedidosA = pedidosAceitos,
                NomeView = "Calendário",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession(),
            });
        }
    }
}