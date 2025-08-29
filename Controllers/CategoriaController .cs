using AtivSistemaDeVendas.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaRepositorio _categoriaRepositorio;

    public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
    {
        _categoriaRepositorio = categoriaRepositorio;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categorias = await _categoriaRepositorio.BuscarTodasCategorias();
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var categoria = await _categoriaRepositorio.BuscarPorId(id);
        if (categoria == null) return NotFound();
        return Ok(categoria);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoriaModel categoria)
    {
        var novaCategoria = await _categoriaRepositorio.Adicionar(categoria);
        return CreatedAtAction(nameof(GetById), new { id = novaCategoria.Id }, novaCategoria);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CategoriaModel categoria)
    {
        var atualizado = await _categoriaRepositorio.Atualizar(categoria, id);
        if (atualizado == null) return NotFound();
        return Ok(atualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var apagado = await _categoriaRepositorio.Apagar(id);
        if (!apagado) return NotFound();
        return NoContent();
    }
}
