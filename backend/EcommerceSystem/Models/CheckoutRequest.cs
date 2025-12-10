// ViewModels/CheckoutRequest.cs
public class CheckoutRequest
{
    public List<ItemCarrinhoViewModel> Itens { get; set; } = new();
    public string MetodoPagamento { get; set; } = string.Empty;
    public string TipoFrete { get; set; } = string.Empty;
    public string CEP { get; set; } = string.Empty;
    public bool AdicionarGarantia { get; set; }
    public bool AdicionarEmbrulho { get; set; }
}