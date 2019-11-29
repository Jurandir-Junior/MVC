using McBonaldsMVC.Enums;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMVC.Controllers
{
    public class AdministradorController : AbstractController
    {
        PedidoRepository pedidoRepository = new PedidoRepository();
        public IActionResult Dashboard()
        {
            var tipoUsuarioSessao = uint.Parse(ObterUsuarioTipoSession());
            if(tipoUsuarioSessao.Equals((uint) TiposUsuario.ADMINISTRADOR))
            {
            var pedidos = pedidoRepository.ObterTodos();
            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            
            foreach (var pedido in pedidos)
            {
                switch(pedido.Status)
                {
                    case (uint) StatusPedido.APROVADO:
                        dashboardViewModel.PedidosAprovados++;
                    break;
                    case (uint) StatusPedido.REPROVADO:
                        dashboardViewModel.PedidosReprovados++;
                    break;
                    default:
                        dashboardViewModel.PedidosPendentes++;
                        dashboardViewModel.Pedidos.Add(pedido);
                    break;
                }
            }
            dashboardViewModel.NomeView = "Dashboard";
            dashboardViewModel.UsuarioEmail = ObterUsuarioSession();

            return View(dashboardViewModel);
            }

            return View("Erro", new RespostaViewModel()
            {
                NomeView = "Dashboard",
                Mensagem = "Você não pode acessar esta parte do site"
            });
        }
    }
}