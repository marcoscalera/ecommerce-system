// Services/ProdutoService.cs
using EcommerceSystem.Repositories;
using EcommerceSystem.Models;
using EcommerceSystem.ViewModels;

namespace EcommerceSystem.Services;

public class ProdutoService
{
    private readonly IProdutoRepository _repository;

    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProdutoViewModel>> GetAllProdutosAsync()
    {
        var produtos = await _repository.GetAllAsync();
        return produtos.Select(p => new ProdutoViewModel
        {
            Id = p.Id,
            Nome = p.Nome,
            Descricao = p.Descricao,
            Preco = p.Preco,
            Estoque = p.Estoque,
            ImagemUrl = p.ImagemUrl
        }).ToList();
    }

    public async Task<ProdutoViewModel?> GetProdutoByIdAsync(int id)
    {
        var produto = await _repository.GetByIdAsync(id);
        if (produto == null) return null;

        return new ProdutoViewModel
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco,
            Estoque = produto.Estoque,
            ImagemUrl = produto.ImagemUrl
        };
    }
}