using Microsoft.AspNetCore.Mvc;
using EcommerceSystem.Patterns.Strategy;

namespace EcommerceSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PagamentoController : ControllerBase
{
    [HttpGet("opcoes")]
    public IActionResult ObterOpcoesPagamento([FromQuery] decimal valor)
    {
        var opcoes = new[]
        {
            new { tipo = "CARTAO", estrategia = (IEstrategiaPagamento)new PagamentoCartao() },
            new { tipo = "BOLETO", estrategia = (IEstrategiaPagamento)new PagamentoBoleto() },
            new { tipo = "PIX", estrategia = (IEstrategiaPagamento)new PagamentoPIX() }
        }.Select(o => new
        {
            tipo = o.tipo,
            nome = o.estrategia.Nome,
            valorFinal = o.estrategia.ProcessarPagamento(valor),
            informacoes = o.estrategia.ObterInformacoes()
        });

        return Ok(opcoes);
    }
}