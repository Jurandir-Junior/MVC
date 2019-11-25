using Microsoft.AspNetCore.Mvc;

namespace RoleTopMVC.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}