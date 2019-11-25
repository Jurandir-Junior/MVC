using Microsoft.AspNetCore.Mvc;

namespace RoleTopMVC.Controllers
{
    public class EventosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}