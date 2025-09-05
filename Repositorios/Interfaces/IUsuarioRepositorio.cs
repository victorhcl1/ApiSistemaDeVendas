using AtivSistemaDeVendas.Models;

public interface IUsuarioRepositorio
{
    Task<List<UsuarioModel>> BuscarTodosUsuarios();
    Task<UsuarioModel> BuscarPorId(int id);
    Task<UsuarioModel> Adicionar(UsuarioModel usuario);
    Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);

    Task<UsuarioModel?> BuscarPorEmailESenha(string email, string senha);
    Task<bool> Apagar(int id);
}
