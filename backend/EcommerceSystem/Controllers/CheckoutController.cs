using Microsoft.AspNetCore.Mvc;
using EcommerceSystem.Services;
using EcommerceSystem.Models;

namespace EcommerceSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CheckoutController : ControllerBase
{
    private readonly CheckoutService _service;

    public CheckoutController(CheckoutService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> ProcessarCheckout([FromBody] CheckoutRequest request)
    {
        try
        {
            var pedido = await _service.ProcessarCheckoutAsync(request);
            return Ok(new { 
                sucesso = true, 
                pedidoId = pedido.Id,
                valorTotal = pedido.ValorTotal,
                mensagem = "Pedido realizado com sucesso!" 
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { sucesso = false, mensagem = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { sucesso = false, mensagem = "Erro ao processar pedido" });
        }
    }

    [HttpGet("pedidos")]
    public async Task<IActionResult> ObterPedidos()
    {
        var pedidos = await _service.ObterPedidosAsync();
        return Ok(pedidos);
    }
}