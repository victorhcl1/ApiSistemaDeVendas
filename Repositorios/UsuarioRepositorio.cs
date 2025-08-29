using AtivSistemaDeVendas.Data;
using AtivSistemaDeVendas.Models;
using Microsoft.EntityFrameworkCore;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly SistemaTarefasDbContext _dbContext;

    public UsuarioRepositorio(SistemaTarefasDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<UsuarioModel>> BuscarTodosUsuarios() =>
        await _dbContext.Usuarios.ToListAsync();

    public async Task<UsuarioModel> BuscarPorId(int id) =>
        await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
    {
        await _dbContext.Usuarios.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();
        return usuario;
    }

    public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
    {
        UsuarioModel usuarioPorId = await BuscarPorId(id);
        if (usuarioPorId == null)
            return null;

        usuarioPorId.Nome = usuario.Nome;
        usuarioPorId.Email = usuario.Email;
        // atualizar outros campos

        _dbContext.Usuarios.Update(usuarioPorId);
        await _dbContext.SaveChangesAsync();

        return usuarioPorId;
    }

    public async Task<bool> Apagar(int id)
    {
        UsuarioModel usuarioPorId = await BuscarPorId(id);
        if (usuarioPorId == null)
            return false;

        _dbContext.Usuarios.Remove(usuarioPorId);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
