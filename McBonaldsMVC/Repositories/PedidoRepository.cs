using System.IO;
using McBonaldsMVC.Models;

namespace McBonaldsMVCatualizado
{
    public class PedidoRepository
    {

        //verificação se o arquivo existe
        private const string PATH = "Database/Pedido.csv";
        public PedidoRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Pedido pedido)
        {
            var linha = new string[] {PrepararRegistroCSV(pedido)};
            File.AppendAllLines(PATH,linha);
            return true;
        }

        private string PrepararRegistroCSV(Pedido pedido)
        {
            Cliente cliente = pedido.Cliente;
            Hamburguer hamburguer = pedido.Hamburguer;
            Shake shake = pedido.Shake;
            return $"Cliente={cliente.Nome}; endereço= {cliente.Endereco}; Telefone= {cliente.Telefone};Email={cliente.Email}; Hamburguer= {hamburguer.Nome}; Hambuguer Preço= {hamburguer.Preco}; Shake= {shake.Nome}; Shake Preço= {shake.Preco}; Data do Pedido= {pedido.DataDoPedido}; Preço Total = {pedido.PrecoTotal}";
        }
    }
}