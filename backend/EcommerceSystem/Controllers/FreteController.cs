using Microsoft.AspNetCore.Mvc;
using EcommerceSystem.Patterns.Strategy;

namespace EcommerceSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FreteController : ControllerBase
{
    [HttpGet("opcoes")]
    public IActionResult ObterOpcoesFrete([FromQuery] decimal valorProdutos)
    {
        var opcoes = new[]
        {
            new { tipo = "PAC", estrategia = (IEstrategiaFrete)new FretePAC() },
            new { tipo = "SEDEX", estrategia = (IEstrategiaFrete)new FreteSEDEX() },
            new { tipo = "EXPRESSO", estrategia = (IEstrategiaFrete)new FreteExpresso() }
        }.Select(o => new
        {
            tipo = o.tipo,
            nome = o.estrategia.Nome,
            valor = o.estrategia.CalcularFrete(valorProdutos, "00000-000"),
            diasEntrega = o.estrategia.DiasEntrega
        });

        return Ok(opcoes);
    }
}