using System;
using RoleTopMVC.Enums;

namespace RoleTopMVC.Models
{
    public class Pedido
    {
        public ulong Id {get;set;}
        public Cliente Cliente {get;set;}
        public Evento Evento {get;set;}
        public DateTime DataDoPedido {get;set;}
        public uint Status {get;set;}

        public Pedido(){
            this.Id = 0;
            this.Cliente = new Cliente();
            this.Evento = new Evento();
            this.Status = (uint) StatusPedido.PENDENTE;
        }
        
    }
}