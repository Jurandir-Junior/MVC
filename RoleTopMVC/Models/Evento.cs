using System;

namespace RoleTopMVC.Models
{
    public class Evento
    {
        public string Nome {get;set;}
        public string Tipo {get;set;}
        public DateTime Hora {get;set;}
        public string Descricao {get;set;}

        public Evento(string nome, string tipo, DateTime hora, string descricao){
            this.Nome = nome;
            this.Tipo = tipo;
            this.Hora = hora;
            this.Descricao = descricao;
        }
    }
}