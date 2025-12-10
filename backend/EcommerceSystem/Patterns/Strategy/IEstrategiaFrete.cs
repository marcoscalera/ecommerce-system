// Patterns/Strategy/IEstrategiaFrete.cs (STRATEGY PATTERN - Comportamental)
namespace EcommerceSystem.Patterns.Strategy;

public interface IEstrategiaFrete
{
    string Nome { get; }
    decimal CalcularFrete(decimal valorProdutos, string cep);
    int DiasEntrega { get; }
}
















