using System;

namespace RoleTopMVC.Models
{
    public class Evento
    {
        public string NomeEvento {get;set;}
        public string TipoEvento {get;set;}
        public DateTime HoraFim {get;set;}
        public DateTime Dia {get;set;}
        public string Descricao {get;set;}

        public Evento()
        {
            
        }
        public Evento(string nomeEvento, string tipoEvento, DateTime horaFim, DateTime dia, string descricao){
            this.NomeEvento = nomeEvento;
            this.TipoEvento = tipoEvento;
            this.HoraFim = horaFim;
            this.Dia = dia;
            this.Descricao = descricao;
        }
    }
}