import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiService } from '../../services/api.service';
import { CartService } from '../../services/cart.service';
import { RouterModule } from '@angular/router';
import { catchError, map, startWith } from 'rxjs/operators';
import { of } from 'rxjs';

@Component({
  selector: 'app-produto-lista',
  standalone: true,
  imports: [CommonModule, RouterModule],
  template: `
    <header class="hero-section text-center">
      <div class="container">
        <h1 class="display-4 mb-3">Tecnologia de Ponta</h1>
        <p class="lead mb-4">Os melhores equipamentos para seu setup, com entrega rápida.</p>
        <button class="btn btn-light btn-lg rounded-pill fw-bold px-5">Ver Ofertas</button>
      </div>
    </header>

    <div class="container pb-5">
      <div *ngIf="state$ | async as state" class="w-100">
        
        <div *ngIf="state.loading" class="loading-overlay">
          <div class="spinner-border text-primary me-2" role="status"></div>
          <span>Buscando produtos...</span>
        </div>

        <div *ngIf="state.error" class="alert alert-danger text-center rounded-4 shadow-sm p-4">
          <i class="bi bi-exclamation-triangle-fill fs-1 mb-3 d-block text-danger"></i>
          <h4 class="alert-heading">Ops! Não conseguimos carregar os produtos.</h4>
          <p>{{ state.error }}</p>
          <hr>
          <p class="mb-0">Verifique se o backend está rodando em <code>http://localhost:5004</code></p>
        </div>

        <div *ngIf="!state.loading && !state.error" class="row g-4">
          <div class="col-sm-6 col-lg-4 col-xl-3" *ngFor="let p of state.produtos">
            <div class="card card-product h-100">
              <div class="img-wrapper">
                <img [src]="p.imagemUrl || 'assets/placeholder.png'" 
                     (error)="handleImageError($event)" 
                     [alt]="p.nome">
              </div>
              <div class="card-body">
                <h5 class="card-title text-truncate" [title]="p.nome">{{ p.nome }}</h5>
                <p class="card-text text-muted small flex-grow-1">{{ p.descricao | slice:0:60 }}...</p>
                
                <div class="d-flex justify-content-between align-items-end mt-3">
                  <div class="price-tag">{{ p.preco | currency:'BRL' }}</div>
                  <button class="btn btn-primary-custom btn-sm" (click)="addCart(p)">
                    <i class="bi bi-cart-plus me-1"></i> Adicionar
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div *ngIf="!state.loading && !state.error && state.produtos.length === 0" class="text-center py-5">
          <i class="bi bi-box-seam fs-1 text-muted"></i>
          <p class="mt-3 text-muted">Nenhum produto encontrado.</p>
        </div>

      </div>
    </div>
  `
})
export class ProdutoListaComponent {
  api = inject(ApiService);
  cart = inject(CartService);

  state$ = this.api.getProdutos().pipe(
    map(produtos => ({ loading: false, error: null, produtos })),
    startWith({ loading: true, error: null, produtos: [] }),
    catchError(err => {
      console.error('Erro ao buscar produtos:', err);
      return of({ 
        loading: false, 
        error: 'Falha na conexão com o servidor. ' + err.message, 
        produtos: [] 
      });
    })
  );

  addCart(p: any) {
    this.cart.adicionar(p);

  }

  handleImageError(event: any) {
    event.target.src = 'https://placehold.co/400x400?text=Sem+Imagem';
  }
}