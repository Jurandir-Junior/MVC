using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Models;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class CadastroController : AbstractController
    {
        ClienteRepository clienteRepositorio = new ClienteRepository();
        public IActionResult Index()
        {
            return View(new BaseViewModel(){
                NomeView = "Cadastro",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        public IActionResult CadastrarCliente(IFormCollection form)
        {
            ViewData["Action"] = "Cadastro";
            try{
                Cliente cliente = new Cliente(
                form["nome"],
                form["senha"],
                form["email"],
                form["cpf"],
                form["endereco"],
                form["telefone"],
                DateTime.Parse(form["data-nascimento"]));
                
                clienteRepositorio.Inserir(cliente);
                
                return View("Sucesso");
            } catch(Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro");
            }            
        }
    }
}