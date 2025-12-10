using Microsoft.AspNetCore.Mvc;
using EcommerceSystem.Services;
using EcommerceSystem.ViewModels;

namespace EcommerceSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarrinhoController : ControllerBase
{
    private readonly CarrinhoService _service;

    public CarrinhoController(CarrinhoService service)
    {
        _service = service;
    }

    [HttpPost("calcular")]
    public async Task<IActionResult> CalcularCarrinho([FromBody] CalcularCarrinhoRequest request)
    {
        var carrinho = await _service.CalcularCarrinhoAsync(request.Itens, request.TipoFrete);
        return Ok(carrinho);
    }

    [HttpPost("validar-estoque")]
    public async Task<IActionResult> ValidarEstoque([FromBody] List<ItemCarrinhoViewModel> itens)
    {
        var valido = await _service.ValidarEstoqueAsync(itens);
        return Ok(new { valido });
    }
}

public class CalcularCarrinhoRequest
{
    public List<ItemCarrinhoViewModel> Itens { get; set; } = new();
    public string TipoFrete { get; set; } = "PAC";
}