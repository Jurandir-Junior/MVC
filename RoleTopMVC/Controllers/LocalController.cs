using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class LocalController : AbstractController
    {
        public IActionResult Index()
        {
            return View(new BaseViewModel()
            {
                NomeView = "Local",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
                
            });
        }
    }
}