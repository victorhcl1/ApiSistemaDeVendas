using AtivSistemaDeVendas.Data;
using AtivSistemaDeVendas.Models;
using Microsoft.EntityFrameworkCore;

public class ProdutoRepositorio : IProdutoRepositorio
{
    private readonly SistemaTarefasDbContext _dbContext;

    public ProdutoRepositorio(SistemaTarefasDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProdutoModel>> BuscarTodosProdutos() =>
        await _dbContext.Produtos.Include(p => p.Categoria).ToListAsync();

    public async Task<ProdutoModel> BuscarPorId(int id) =>
        await _dbContext.Produtos.Include(p => p.Categoria)
                                 .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
    {
        await _dbContext.Produtos.AddAsync(produto);
        await _dbContext.SaveChangesAsync();
        return produto;
    }

    public async Task<ProdutoModel> Atualizar(ProdutoModel produto, int id)
    {
        var produtoPorId = await BuscarPorId(id);
        if (produtoPorId == null) return null;

        produtoPorId.Nome = produto.Nome;
        produtoPorId.Preco = produto.Preco;
        produtoPorId.CategoriaId = produto.CategoriaId;
        // atualizar outros campos

        _dbContext.Produtos.Update(produtoPorId);
        await _dbContext.SaveChangesAsync();
        return produtoPorId;
    }

    public async Task<bool> Apagar(int id)
    {
        var produtoPorId = await BuscarPorId(id);
        if (produtoPorId == null) return false;

        _dbContext.Produtos.Remove(produtoPorId);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}