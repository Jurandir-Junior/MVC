using System.Collections.Generic;
using McBonaldsMVC.Models;

namespace McBonaldsMVC.ViewModels
{
    public class PedidoViewModel
    {
        public List<Hamburguer> Hamburgueres {get;set;}
        public List<Shake> Shake {get;set;}
        public string NomeUsuario {get; set;}
        public Cliente Cliente {get; set;}

        public PedidoViewModel()
        {
            this.Hamburgueres = new List<Hamburguer>();
            this.Shake = new List<Shake>();
            this.NomeUsuario = "Jovem";
            this.Cliente = new Cliente();
        }

    }
}