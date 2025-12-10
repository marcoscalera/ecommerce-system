// Models/Pedido.cs
public class Pedido
{
    public int Id { get; set; }
    public DateTime DataPedido { get; set; }
    public decimal ValorTotal { get; set; }
    public string Status { get; set; } = "Pendente";
    public string MetodoPagamento { get; set; } = string.Empty;
    public string TipoFrete { get; set; } = string.Empty;
    public decimal ValorFrete { get; set; }
    public List<ItemPedido> Itens { get; set; } = new();
}
