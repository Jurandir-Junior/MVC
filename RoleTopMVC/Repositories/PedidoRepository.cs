using System;
using System.Collections.Generic;
using System.IO;
using RoleTopMVC.Enums;
using RoleTopMVC.Models;

namespace RoleTopMVC.Repositories
{
    public class PedidoRepository : RepositoryBase
    {
        private const string PATH = "Database/Pedido.csv";

        public PedidoRepository(){
            if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Pedido pedido){
            var quantidadePedidos = File.ReadAllLines(PATH).Length;
            pedido.Id = (ulong) ++quantidadePedidos;
            var linha = new string[] { PrepararPedidoCSV (pedido)};
            File.AppendAllLines(PATH, linha);

            return true;
        }

        public List<Pedido> ObterTodosPorCliente(string emailCliente){
            var pedidos = ObterTodos();
            List<Pedido> pedidosCliente = new List<Pedido>();

            foreach(var pedido in pedidos){
                if(pedido.Cliente.Email.Equals(emailCliente))
                {
                    pedidosCliente.Add(pedido);
                }
            }
            return pedidosCliente;
        }

        public Pedido ObterPor(ulong id){
            var pedidosTotais = ObterTodos();
            foreach(var pedido in pedidosTotais){
                if(pedido.Id == id){
                    return pedido;
                }
            }
            return null;
        }

        public List<Pedido> ObterTodos(){
            var linhas = File.ReadAllLines(PATH);
            List<Pedido> pedidos = new List<Pedido>();

            foreach(var linha in linhas){
                Pedido pedido = new Pedido();

                pedido.Id = ulong.Parse(ExtrairValorDoCampo("id", linha));
                pedido.Status = uint.Parse(ExtrairValorDoCampo("status_pedido", linha));
                pedido.Cliente.Nome = ExtrairValorDoCampo("cliente_nome", linha);
                pedido.Cliente.Telefone = ExtrairValorDoCampo("cliente_telefone", linha);
                pedido.Cliente.Email = ExtrairValorDoCampo("cliente_email", linha);
                pedido.Evento.NomeEvento = ExtrairValorDoCampo("evento_nome", linha);
                pedido.Evento.TipoEvento = ExtrairValorDoCampo("evento_tipo", linha);
                pedido.Evento.Dia = DateTime.Parse(ExtrairValorDoCampo("evento_inicio", linha));
                pedido.Evento.HoraFim = DateTime.Parse(ExtrairValorDoCampo("evento_fim", linha));
                pedido.DataDoPedido = DateTime.Parse(ExtrairValorDoCampo("data_pedido", linha));

                pedidos.Add(pedido);
            }
            return pedidos;
        }

        public List<Pedido> ObterAprovados(){
            var aprovados = ObterTodos();
            List<Pedido> pedidosA = new List<Pedido>();
            foreach(var pedido in aprovados){
                if(pedido.Status == 1){
                    pedidosA.Add(pedido);
                }
            }
            return pedidosA;
        }

        public bool Atualizar(Pedido pedido){
            var pedidosTotais = File.ReadAllLines(PATH);
            var pedidoCSV = PrepararPedidoCSV(pedido);
            var linhaPedido = -1;
            var resultado = false;

            for(int i = 0; i < pedidosTotais.Length; i++){
                var idConvertido = ulong.Parse(ExtrairValorDoCampo("id",pedidosTotais[i]));
                if(pedido.Id.Equals(idConvertido)){
                    linhaPedido = i;
                    resultado = true;
                    break;
                }
            }

            if(resultado){
                pedidosTotais[linhaPedido] = pedidoCSV;
                File.WriteAllLines(PATH, pedidosTotais);
            }
            return resultado;
        }

        private string PrepararPedidoCSV(Pedido pedido){
            Cliente c = pedido.Cliente;
            Evento e = pedido.Evento;

            return $"id={pedido.Id};status_pedido={pedido.Status};cliente_nome={c.Nome};cliente_telefone={c.Telefone};cliente_email={c.Email};evento_nome={e.NomeEvento};evento_tipo={e.TipoEvento};evento_inicio={e.Dia};evento_fim={e.HoraFim};data_pedido={pedido.DataDoPedido}";
        }
    }
}