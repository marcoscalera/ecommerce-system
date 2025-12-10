// Controllers/ProdutosController.cs
using Microsoft.AspNetCore.Mvc;
using EcommerceSystem.Services;

namespace EcommerceSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly ProdutoService _service;

    public ProdutosController(ProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var produtos = await _service.GetAllProdutosAsync();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var produto = await _service.GetProdutoByIdAsync(id);
        if (produto == null)
            return NotFound();

        return Ok(produto);
    }
}







