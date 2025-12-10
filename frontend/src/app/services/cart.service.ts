import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Produto, ItemCarrinho } from '../models/models';

@Injectable({ providedIn: 'root' })
export class CartService {
  private itensSource = new BehaviorSubject<ItemCarrinho[]>([]);
  itens$ = this.itensSource.asObservable();

  adicionar(produto: Produto) {
    const atuais = this.itensSource.value;
    const existente = atuais.find(i => i.produtoId === produto.id);

    if (existente) {
      existente.quantidade++;
      existente.subtotal = existente.quantidade * existente.preco;
    } else {
      atuais.push({
        produtoId: produto.id,
        nome: produto.nome,
        preco: produto.preco,
        quantidade: 1,
        subtotal: produto.preco,
        imagemUrl: produto.imagemUrl
      });
    }
    this.atualizar(atuais);
  }

  remover(id: number) {
    const atuais = this.itensSource.value.filter(i => i.produtoId !== id);
    this.atualizar(atuais);
  }

  limpar() {
    this.atualizar([]);
  }

  private atualizar(itens: ItemCarrinho[]) {
    this.itensSource.next(itens);
    localStorage.setItem('cart', JSON.stringify(itens)); 
  }

  getSubtotal() {
    return this.itensSource.value.reduce((acc, item) => acc + item.subtotal, 0);
  }
}