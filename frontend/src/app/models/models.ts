export interface Produto {
  id: number;
  nome: string;
  descricao: string;
  preco: number;
  estoque: number;
  imagemUrl: string;
}

export interface ItemCarrinho {
  produtoId: number;
  nome: string;
  preco: number;
  quantidade: number;
  subtotal: number;
  imagemUrl: string;
}

export interface CarrinhoResumo {
  itens: ItemCarrinho[];
  subtotal: number;
  valorFrete: number;
  total: number;
}

export interface PedidoRequest {
  itens: ItemCarrinho[];
  metodoPagamento: string;
  tipoFrete: string;
  cep: string;
  adicionarGarantia: boolean;
  adicionarEmbrulho: boolean;
}