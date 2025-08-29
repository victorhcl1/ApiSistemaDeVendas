using AtivSistemaDeVendas.Data;
using AtivSistemaDeVendas.Models;
using Microsoft.EntityFrameworkCore;

public class PedidoProdutoRepositorio : IPedidoProdutoRepositorio
{
    private readonly SistemaTarefasDbContext _dbContext;

    public PedidoProdutoRepositorio(SistemaTarefasDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<PedidoProdutoModel>> BuscarTodos()
    {
        return await _dbContext.PedidoProdutos // 👈 Nome certo aqui
            .Include(pp => pp.Pedido)
            .Include(pp => pp.Produto)
            .ToListAsync();
    }

    public async Task<PedidoProdutoModel?> BuscarPorId(int id)
    {
        return await _dbContext.PedidoProdutos
            .Include(pp => pp.Pedido)
            .Include(pp => pp.Produto)
            .FirstOrDefaultAsync(pp => pp.Id == id);
    }

    public async Task<PedidoProdutoModel> Adicionar(PedidoProdutoModel pedidoProduto)
    {
        await _dbContext.PedidoProdutos.AddAsync(pedidoProduto);
        await _dbContext.SaveChangesAsync();
        return pedidoProduto;
    }

    public async Task<PedidoProdutoModel?> Atualizar(PedidoProdutoModel pedidoProduto, int id)
    {
        var existente = await BuscarPorId(id);
        if (existente == null) return null;

        existente.PedidoId = pedidoProduto.PedidoId;
        existente.ProdutoId = pedidoProduto.ProdutoId;
        existente.Quantidade = pedidoProduto.Quantidade;
        existente.PrecoUnitario = pedidoProduto.PrecoUnitario;

        _dbContext.PedidoProdutos.Update(existente);
        await _dbContext.SaveChangesAsync();

        return existente;
    }

    public async Task<bool> Apagar(int id)
    {
        var existente = await BuscarPorId(id);
        if (existente == null) return false;

        _dbContext.PedidoProdutos.Remove(existente);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
