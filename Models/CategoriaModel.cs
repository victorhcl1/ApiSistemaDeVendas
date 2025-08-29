using AtivSistemaDeVendas.Models;
using System.Collections.Generic;

namespace AtivSistemaDeVendas.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        // Relacionamento 1:N -> Uma categoria pode ter vários produtos
        public ICollection<ProdutoModel> Produtos { get; set; } = new List<ProdutoModel>();
    }
}
