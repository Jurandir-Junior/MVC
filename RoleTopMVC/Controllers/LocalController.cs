using Microsoft.AspNetCore.Mvc;

namespace RoleTopMVC.Controllers
{
    public class LocalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}