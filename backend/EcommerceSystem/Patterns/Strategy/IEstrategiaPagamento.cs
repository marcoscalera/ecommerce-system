// Patterns/Strategy/IEstrategiaPagamento.cs
public interface IEstrategiaPagamento
{
    string Nome { get; }
    decimal ProcessarPagamento(decimal valor);
    string ObterInformacoes();
}