using System;

namespace RoleTopMVC.Models
{
    public class Evento
    {
        public string Nome {get;set;}
        public string Tipo {get;set;}
        public DateTime HoraInicio {get;set;}
        public DateTime HoraFim {get;set;}
        public DateTime Dia {get;set;}
        public string Descricao {get;set;}

        public Evento()
        {
            
        }
        public Evento(string nome, string tipo, DateTime horaInicio, DateTime horaFim, DateTime dia, string descricao){
            this.Nome = nome;
            this.Tipo = tipo;
            this.HoraInicio = horaInicio;
            this.HoraFim = horaFim;
            this.Dia = dia;
            this.Descricao = descricao;
        }
    }
}