import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Produto, PedidoRequest, CarrinhoResumo } from '../models/models';

@Injectable({ providedIn: 'root' })
export class ApiService {
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl;

  // Produtos
  getProdutos() {
    return this.http.get<Produto[]>(`${this.apiUrl}/produtos`);
  }

  getProdutoById(id: number) {
    return this.http.get<Produto>(`${this.apiUrl}/produtos/${id}`);
  }

  // Frete e Pagamento
  getOpcoesFrete(valor: number) {
    return this.http.get<any[]>(`${this.apiUrl}/frete/opcoes?valorProdutos=${valor}`);
  }

  getOpcoesPagamento(valor: number) {
    return this.http.get<any[]>(`${this.apiUrl}/pagamento/opcoes?valor=${valor}`);
  }

  // Carrinho e Checkout
  calcularCarrinho(itens: any[], tipoFrete: string) {
    return this.http.post<CarrinhoResumo>(`${this.apiUrl}/carrinho/calcular`, { itens, tipoFrete });
  }

  finalizarPedido(pedido: PedidoRequest) {
    return this.http.post(`${this.apiUrl}/checkout`, pedido);
  }
}