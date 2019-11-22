using System;
using System.Collections.Generic;
using System.IO;
using McBonaldsMVC.Models;

namespace McBonaldsMVC.Repositories
{
    public class PedidoRepository : RepositoryBase
    {
        private const string PATH = "Database/Pedido.csv";
        public PedidoRepository () 
        {
            if (!File.Exists(PATH)) {
                File.Create(PATH).Close();
            }
        
        }
            public bool Inserir(Pedido pedido)
            {
                var linha = new string[] {PrepararPedidoCSV(pedido)};
                File.AppendAllLines(PATH,linha);

                return true;
            }

            public List<Pedido> ObterTodos() // obtem o histórico de pedidos para o adm
            {
                var linhas = File.ReadAllLines(PATH); // File.ReadAllLines lê o CSV
                List<Pedido> pedidos = new List<Pedido>();
                foreach(var linha in linhas)
                {
                    Pedido pedido = new Pedido();
                    pedido.Cliente.Nome = ExtrairValorDoCampo("cliente_nome", linha);
                    pedido.Cliente.Endereco = ExtrairValorDoCampo("cliente_endereco", linha);
                    pedido.Cliente.Telefone = ExtrairValorDoCampo("cliente_telefone", linha);
                    pedido.Cliente.Email = ExtrairValorDoCampo("cliente_email", linha);

                    pedido.Hamburguer.Nome = ExtrairValorDoCampo("hamburguer_nome", linha);
                    pedido.Hamburguer.Preco = double.Parse(ExtrairValorDoCampo("hamburguer_preco", linha));

                    pedido.Shake.Nome = ExtrairValorDoCampo("shake_nome", linha);
                    pedido.Shake.Preco = double.Parse(ExtrairValorDoCampo("shake_preco", linha));
                    pedido.DataDoPedido = DateTime.Parse(ExtrairValorDoCampo("data_pedido", linha));
                    pedido.PrecoTotal = double.Parse(ExtrairValorDoCampo("preco_total", linha));

                    pedidos.Add(pedido);
                    
                }
                return pedidos;
            }

            public List<Pedido> ObterTodosPorCliente(string email) //histórico de pedidos para o usuário
            {
                var pedidosTotais = ObterTodos();
                var pedidosCliente = new List<Pedido>();
                foreach(var pedido in pedidosTotais)
                {
                    if(pedido.Cliente.Email.Equals(email))
                    {
                        pedidosCliente.Add(pedido);
                    }
                }
                return pedidosCliente;
            }

            
            private string PrepararPedidoCSV(Pedido pedido)
            {
                Cliente c = pedido.Cliente;
                Hamburguer h = pedido.Hamburguer;
                Shake s = pedido.Shake;

                return $"cliente_nome={c.Nome};cliente_endereco={c.Endereco};cliente_telefone={c.Telefone};cliente_email={c.Email};hamburguer_nome={h.Nome};hamburguer_preco={h.Preco};shake_nome={s.Nome};shake_preco={s.Preco};data_pedido={pedido.DataDoPedido};preco_total={pedido.PrecoTotal}";
            }
    }
}