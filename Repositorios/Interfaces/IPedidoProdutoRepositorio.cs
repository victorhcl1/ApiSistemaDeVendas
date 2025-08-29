using AtivSistemaDeVendas.Models;

public interface IPedidoProdutoRepositorio
{
    Task<List<PedidoProdutoModel>> BuscarTodos();
    Task<PedidoProdutoModel?> BuscarPorId(int id);
    Task<PedidoProdutoModel> Adicionar(PedidoProdutoModel pedidoProduto);
    Task<PedidoProdutoModel?> Atualizar(PedidoProdutoModel pedidoProduto, int id);
    Task<bool> Apagar(int id);
}
