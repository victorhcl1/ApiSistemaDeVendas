using AtivSistemaDeVendas.Models;
using System;
using System.Collections.Generic;

namespace AtivSistemaDeVendas.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pendente";
        public string FormaPagamento { get; set; } = string.Empty;

        // Chave estrangeira para Usuario
        public int UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }

        // Relacionamento N:N -> Pedido tem vários produtos
        public ICollection<PedidoProdutoModel> PedidosProdutos { get; set; } = new List<PedidoProdutoModel>();
    }
}
