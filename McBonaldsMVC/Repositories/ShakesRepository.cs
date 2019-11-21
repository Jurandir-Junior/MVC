using System.Collections.Generic;
using System.IO;
using McBonaldsMVC.Models;

namespace McBonaldsMVCatualizado.Repositories
{
    public class ShakesRepository
    {
        private const string PATH = "Database/Shake.csv";

        public ShakesRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public double ObterPrecoDe(string nomeShake)
        {
            var lista = ObterTodos();
            double preco = 0.0;
            foreach (var item in lista)
            {
                if(item.Nome.Equals(nomeShake))
                {
                    preco = item.Preco;
                    break;
                }
            }
            return preco;
        }

        public List<Shake> ObterTodos()
        {
            List<Shake> shakes = new List<Shake>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach(var linha in linhas)
            {
                Shake s = new Shake();
                string[] dados = linha.Split(";");
                s.Nome = dados[0];
                s.Preco = double.Parse(dados[1]);
                shakes.Add(s);
            }
            return shakes;
        }
    }

    
}