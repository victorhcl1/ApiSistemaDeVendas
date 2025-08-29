using AtivSistemaDeVendas.Data;
using AtivSistemaDeVendas.Models;
using Microsoft.EntityFrameworkCore;

public class PedidoRepositorio : IPedidoRepositorio
{
    private readonly SistemaTarefasDbContext _dbContext;

    public PedidoRepositorio(SistemaTarefasDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<PedidoModel>> BuscarTodosPedidos() =>
        await _dbContext.Pedidos.Include(p => p.PedidosProdutos).ToListAsync();

    public async Task<PedidoModel> BuscarPorId(int id) =>
        await _dbContext.Pedidos.Include(p => p.PedidosProdutos)
                                .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<PedidoModel> Adicionar(PedidoModel pedido)
    {
        await _dbContext.Pedidos.AddAsync(pedido);
        await _dbContext.SaveChangesAsync();
        return pedido;
    }

    public async Task<PedidoModel> Atualizar(PedidoModel pedido, int id)
    {
        var pedidoPorId = await BuscarPorId(id);
        if (pedidoPorId == null) return null;

        pedidoPorId.Status = pedido.Status;
        pedidoPorId.FormaPagamento = pedido.FormaPagamento;
        // atualizar outros campos

        _dbContext.Pedidos.Update(pedidoPorId);
        await _dbContext.SaveChangesAsync();
        return pedidoPorId;
    }

    public async Task<bool> Apagar(int id)
    {
        var pedidoPorId = await BuscarPorId(id);
        if (pedidoPorId == null) return false;

        _dbContext.Pedidos.Remove(pedidoPorId);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}