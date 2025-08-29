using AtivSistemaDeVendas.Models;
using System.Collections.Generic;

namespace AtivSistemaDeVendas.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }

        // Chave estrangeira para Categoria
        public int CategoriaId { get; set; }
        public CategoriaModel? Categoria { get; set; }

        // Relacionamento N:N -> Produto pode estar em vários pedidos
        public ICollection<PedidoProdutoModel> PedidosProdutos { get; set; } = new List<PedidoProdutoModel>();
    }
}
