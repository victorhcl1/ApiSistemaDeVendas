using AtivSistemaDeVendas.Models;

public interface IProdutoRepositorio
{
    Task<List<ProdutoModel>> BuscarTodosProdutos();
    Task<ProdutoModel> BuscarPorId(int id);
    Task<ProdutoModel> Adicionar(ProdutoModel produto);
    Task<ProdutoModel> Atualizar(ProdutoModel produto, int id);
    Task<bool> Apagar(int id);
}