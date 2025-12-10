import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartService } from '../../services/cart.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-carrinho',
  standalone: true,
  imports: [CommonModule, RouterModule],
  template: `
    <div class="container py-5">
      <div class="row g-5">
        <div class="col-lg-8">
          <h2 class="fw-bold mb-4">Seu Carrinho</h2>
          
          <div *ngIf="(cart.itens$ | async)?.length === 0" class="text-center py-5 bg-white rounded-4 shadow-sm">
            <i class="bi bi-cart-x fs-1 text-muted mb-3 d-block"></i>
            <h3>Seu carrinho está vazio</h3>
            <p class="text-muted">Explore nossos produtos e encontre o que precisa.</p>
            <a routerLink="/" class="btn btn-primary-custom mt-3">Ir para Loja</a>
          </div>

          <div *ngFor="let item of cart.itens$ | async" class="card border-0 shadow-sm mb-3 rounded-4 overflow-hidden">
            <div class="card-body p-4">
              <div class="d-flex align-items-center gap-4">
                <img [src]="item.imagemUrl" class="rounded-3 bg-light object-fit-contain" width="80" height="80">
                <div class="flex-grow-1">
                  <h5 class="mb-1 fw-bold">{{ item.nome }}</h5>
                  <div class="text-primary fw-bold">{{ item.preco | currency:'BRL' }}</div>
                </div>
                <div class="d-flex align-items-center gap-3">
                  <span class="badge bg-light text-dark border px-3 py-2 rounded-pill">Qtd: {{ item.quantidade }}</span>
                  <div class="fw-bold fs-5 text-end" style="min-width: 100px;">
                    {{ item.subtotal | currency:'BRL' }}
                  </div>
                  <button class="btn btn-outline-danger btn-sm rounded-circle p-2" (click)="cart.remover(item.produtoId)">
                    <i class="bi bi-trash"></i>
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div class="col-lg-4" *ngIf="(cart.itens$ | async)?.length">
          <div class="card border-0 shadow-sm rounded-4 sticky-top" style="top: 100px; z-index: 1;">
            <div class="card-body p-4">
              <h4 class="fw-bold mb-4">Resumo do Pedido</h4>
              <div class="d-flex justify-content-between mb-2">
                <span class="text-muted">Subtotal</span>
                <span class="fw-bold">{{ cart.getSubtotal() | currency:'BRL' }}</span>
              </div>
              <div class="d-flex justify-content-between mb-4">
                <span class="text-muted">Frete</span>
                <span class="text-success small">Calculado no checkout</span>
              </div>
              <hr class="my-4">
              <div class="d-flex justify-content-between align-items-center mb-4">
                <span class="fs-5 fw-bold">Total</span>
                <span class="fs-4 fw-bold text-primary">{{ cart.getSubtotal() | currency:'BRL' }}</span>
              </div>
              <a routerLink="/checkout" class="btn btn-primary-custom w-100 py-3 fs-6">
                Seguir para Pagamento
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
  `
})
export class CarrinhoComponent {
  cart = inject(CartService);
}