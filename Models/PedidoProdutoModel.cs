using AtivSistemaDeVendas.Models;

namespace AtivSistemaDeVendas.Models
{
    public class PedidoProdutoModel
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public PedidoModel? Pedido { get; set; }

        public int ProdutoId { get; set; }
        public ProdutoModel? Produto { get; set; }

        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
