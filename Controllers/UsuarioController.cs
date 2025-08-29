using AtivSistemaDeVendas.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;

    public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var usuario = await _usuarioRepositorio.BuscarPorId(id);
        if (usuario == null) return NotFound();
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UsuarioModel usuario)
    {
        var novoUsuario = await _usuarioRepositorio.Adicionar(usuario);
        return CreatedAtAction(nameof(GetById), new { id = novoUsuario.Id }, novoUsuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UsuarioModel usuario)
    {
        var atualizado = await _usuarioRepositorio.Atualizar(usuario, id);
        if (atualizado == null) return NotFound();
        return Ok(atualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var apagado = await _usuarioRepositorio.Apagar(id);
        if (!apagado) return NotFound();
        return NoContent();
    }
}
