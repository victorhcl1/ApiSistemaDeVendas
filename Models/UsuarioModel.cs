using AtivSistemaDeVendas.Models;
using System.Collections.Generic;

namespace AtivSistemaDeVendas.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        // Relacionamento 1:N -> Um usuário pode ter vários pedidos
        //public ICollection<PedidoModel> Pedidos { get; set; } = new List<PedidoModel>();
    }
}
