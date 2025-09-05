using AtivSistemaDeVendas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PedidoProdutoController : ControllerBase
{
    private readonly IPedidoProdutoRepositorio _pedidoProdutoRepositorio;

    public PedidoProdutoController(IPedidoProdutoRepositorio pedidoProdutoRepositorio)
    {
        _pedidoProdutoRepositorio = pedidoProdutoRepositorio;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pedidosProdutos = await _pedidoProdutoRepositorio.BuscarTodos();
        return Ok(pedidosProdutos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pedidoProduto = await _pedidoProdutoRepositorio.BuscarPorId(id);
        if (pedidoProduto == null) return NotFound();
        return Ok(pedidoProduto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PedidoProdutoModel pedidoProduto)
    {
        if (pedidoProduto == null) return BadRequest("Dados inválidos.");

        var novoPedidoProduto = await _pedidoProdutoRepositorio.Adicionar(pedidoProduto);
        return CreatedAtAction(nameof(GetById), new { id = novoPedidoProduto.Id }, novoPedidoProduto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PedidoProdutoModel pedidoProduto)
    {
        if (pedidoProduto == null) return BadRequest("Dados inválidos.");

        var atualizado = await _pedidoProdutoRepositorio.Atualizar(pedidoProduto, id);
        if (atualizado == null) return NotFound();

        return Ok(atualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var apagado = await _pedidoProdutoRepositorio.Apagar(id);
        if (!apagado) return NotFound();

        return NoContent();
    }
}
