using AtivSistemaDeVendas.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoRepositorio _pedidoRepositorio;

    public PedidoController(IPedidoRepositorio pedidoRepositorio)
    {
        _pedidoRepositorio = pedidoRepositorio;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pedidos = await _pedidoRepositorio.BuscarTodosPedidos();
        return Ok(pedidos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pedido = await _pedidoRepositorio.BuscarPorId(id);
        if (pedido == null) return NotFound();
        return Ok(pedido);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PedidoModel pedido)
    {
        var novoPedido = await _pedidoRepositorio.Adicionar(pedido);
        return CreatedAtAction(nameof(GetById), new { id = novoPedido.Id }, novoPedido);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PedidoModel pedido)
    {
        var atualizado = await _pedidoRepositorio.Atualizar(pedido, id);
        if (atualizado == null) return NotFound();
        return Ok(atualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var apagado = await _pedidoRepositorio.Apagar(id);
        if (!apagado) return NotFound();
        return NoContent();
    }
}
