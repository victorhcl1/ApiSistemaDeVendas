using AtivSistemaDeVendas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepositorio _produtoRepositorio;

    public ProdutoController(IProdutoRepositorio produtoRepositorio)
    {
        _produtoRepositorio = produtoRepositorio;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var produtos = await _produtoRepositorio.BuscarTodosProdutos();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var produto = await _produtoRepositorio.BuscarPorId(id);
        if (produto == null) return NotFound();
        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProdutoModel produto)
    {
        var novoProduto = await _produtoRepositorio.Adicionar(produto);
        return CreatedAtAction(nameof(GetById), new { id = novoProduto.Id }, novoProduto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProdutoModel produto)
    {
        var atualizado = await _produtoRepositorio.Atualizar(produto, id);
        if (atualizado == null) return NotFound();
        return Ok(atualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var apagado = await _produtoRepositorio.Apagar(id);
        if (!apagado) return NotFound();
        return NoContent();
    }
}
