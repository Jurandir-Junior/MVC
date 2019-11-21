using System;

namespace SenaizinhoMVC.Models
{
    public class Aluno
    {
        public string Nome {get; set;}
        public string Endereco {get; set;}
        public string Senha {get; set;}
        public string Telefone {get; set;}
        public string Email {get; set;}
        public DateTime DataNascimento {get; set;}
        public string Curso {get; set;}

        public Aluno()
        {

        }

        public Aluno(string nome, string endereco, string telefone, string senha, string email, DateTime dataNascimento, string curso)
        {
            this.Nome = nome;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.Senha = senha;
            this.Email = email;
            this.DataNascimento = dataNascimento;
            this.Curso = curso;
        }
    }
}