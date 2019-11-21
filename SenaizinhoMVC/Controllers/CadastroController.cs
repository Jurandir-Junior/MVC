using System;
using SenaizinhoMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SenaizinhoMVC.Controllers
{
    
    public class CadastroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarAluno(IFormCollection form)
        {
            ViewData["Action"] = "Cadastro";
            try{
                Aluno aluno = new Aluno(
                form["nome"],
                form["endereco"],
                form["telefone"],
                form["senha"],
                form["email"],
                DateTime.Parse(form["data-nascimento"]),
                form["curso"]);

                return View("Sucesso");
            } catch(Exception e)
            {
                return View("Erro");
            }   
        }
    }
}