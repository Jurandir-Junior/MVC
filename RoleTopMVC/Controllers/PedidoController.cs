using Microsoft.AspNetCore.Mvc;

namespace RoleTopMVC.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index(){
            return View();
        }
    }
}