using AtivSistemaDeVendas.Data;
using AtivSistemaDeVendas.Models;
using Microsoft.EntityFrameworkCore;

public class CategoriaRepositorio : ICategoriaRepositorio
{
    private readonly SistemaTarefasDbContext _dbContext;

    public CategoriaRepositorio(SistemaTarefasDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CategoriaModel>> BuscarTodasCategorias() =>
        await _dbContext.Categorias.Include(c => c.Produtos).ToListAsync();

    public async Task<CategoriaModel> BuscarPorId(int id) =>
        await _dbContext.Categorias.Include(c => c.Produtos)
                                   .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<CategoriaModel> Adicionar(CategoriaModel categoria)
    {
        await _dbContext.Categorias.AddAsync(categoria);
        await _dbContext.SaveChangesAsync();
        return categoria;
    }

    public async Task<CategoriaModel> Atualizar(CategoriaModel categoria, int id)
    {
        var categoriaPorId = await BuscarPorId(id);
        if (categoriaPorId == null) return null;

        categoriaPorId.Nome = categoria.Nome;
        // atualizar outros campos

        _dbContext.Categorias.Update(categoriaPorId);
        await _dbContext.SaveChangesAsync();
        return categoriaPorId;
    }

    public async Task<bool> Apagar(int id)
    {
        var categoriaPorId = await BuscarPorId(id);
        if (categoriaPorId == null) return false;

        _dbContext.Categorias.Remove(categoriaPorId);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}