import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../../services/api.service';
import { CartService } from '../../services/cart.service';
import { ItemCarrinho } from '../../models/models';

@Component({
  selector: 'app-checkout',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <div class="container py-5">
      <h2 class="mb-4">Checkout</h2>
      
      <div class="row">
        <div class="col-md-8">
          <div class="card mb-4 shadow-sm">
            <div class="card-header bg-white fw-bold">1. Endereço e Frete</div>
            <div class="card-body">
              <label class="form-label">CEP</label>
              <div class="input-group mb-3">
                <input type="text" class="form-control" [(ngModel)]="cep" placeholder="00000-000">
                <button class="btn btn-outline-secondary" (click)="carregarOpcoesFrete()">Calcular Frete</button>
              </div>

              <div *ngIf="opcoesFrete.length" class="mb-3">
                <label class="form-label">Escolha o Frete:</label>
                <select class="form-select" [(ngModel)]="freteSelecionado" (change)="atualizarTotal()">
                  <option *ngFor="let f of opcoesFrete" [ngValue]="f">
                    {{ f.nome }} - {{ f.valor | currency:'BRL' }} ({{ f.diasEntrega }} dias)
                  </option>
                </select>
              </div>
            </div>
          </div>

          <div class="card mb-4 shadow-sm">
            <div class="card-header bg-white fw-bold">2. Extras</div>
            <div class="card-body">
              <div class="form-check">
                <input class="form-check-input" type="checkbox" [(ngModel)]="garantia" (change)="atualizarTotal()">
                <label class="form-check-label">Garantia Estendida (+10%)</label>
              </div>
              <div class="form-check">
                <input class="form-check-input" type="checkbox" [(ngModel)]="embrulho" (change)="atualizarTotal()">
                <label class="form-check-label">Embrulho para Presente (+R$ 15,00)</label>
              </div>
            </div>
          </div>

          <div class="card mb-4 shadow-sm">
            <div class="card-header bg-white fw-bold">3. Pagamento</div>
            <div class="card-body">
              <select class="form-select" [(ngModel)]="pagamentoSelecionado" (change)="atualizarTotal()">
                <option *ngFor="let p of opcoesPagamento" [ngValue]="p">
                  {{ p.nome }} ({{ p.informacoes }})
                </option>
              </select>
            </div>
          </div>
        </div>

        <div class="col-md-4">
          <div class="card shadow-sm border-primary">
            <div class="card-body">
              <h4 class="card-title d-flex justify-content-between align-items-center mb-3">
                <span class="text-primary">Resumo</span>
                <span class="badge bg-primary rounded-pill">{{ itens.length }}</span>
              </h4>
              <ul class="list-group mb-3">
                <li class="list-group-item d-flex justify-content-between lh-sm">
                  <div><h6 class="my-0">Subtotal</h6></div>
                  <span class="text-muted">{{ subtotal | currency:'BRL' }}</span>
                </li>
                <li class="list-group-item d-flex justify-content-between lh-sm" *ngIf="freteSelecionado">
                  <div><h6 class="my-0">Frete</h6></div>
                  <span class="text-muted">{{ freteSelecionado.valor | currency:'BRL' }}</span>
                </li>
                 <li class="list-group-item d-flex justify-content-between lh-sm" *ngIf="valorExtras > 0">
                  <div><h6 class="my-0">Extras</h6></div>
                  <span class="text-muted">{{ valorExtras | currency:'BRL' }}</span>
                </li>
                <li class="list-group-item d-flex justify-content-between bg-light">
                  <span class="fw-bold">Total (Aprox)</span>
                  <strong class="text-success">{{ totalEstimado | currency:'BRL' }}</strong>
                </li>
              </ul>

              <button class="w-100 btn btn-primary btn-lg" (click)="finalizarCompra()" [disabled]="!podeFinalizar()">
                Confirmar Pedido
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  `
})
export class CheckoutComponent implements OnInit {
  api = inject(ApiService);
  cart = inject(CartService);
  router = inject(Router);

  itens: ItemCarrinho[] = [];
  subtotal = 0;
  
  cep = '';
  opcoesFrete: any[] = [];
  freteSelecionado: any = null;
  
  garantia = false;
  embrulho = false;
  valorExtras = 0;

  opcoesPagamento: any[] = [];
  pagamentoSelecionado: any = null;

  totalEstimado = 0;

  ngOnInit() {
    this.cart.itens$.subscribe(itens => {
      this.itens = itens;
      this.subtotal = itens.reduce((acc, i) => acc + i.subtotal, 0);
      this.atualizarTotal();
    });

    this.carregarOpcoesPagamento();
  }

  carregarOpcoesFrete() {
    if(!this.cep) return;
    this.api.getOpcoesFrete(this.subtotal).subscribe(opcoes => {
      this.opcoesFrete = opcoes;
      this.freteSelecionado = opcoes[0]; 
      this.atualizarTotal();
    });
  }

  carregarOpcoesPagamento() {
    this.api.getOpcoesPagamento(this.subtotal).subscribe(opcoes => {
      this.opcoesPagamento = opcoes;
      this.pagamentoSelecionado = opcoes[0];
    });
  }

  atualizarTotal() {
    let total = this.subtotal;
    
    if (this.freteSelecionado) {
      total += this.freteSelecionado.valor;
    }

    this.valorExtras = 0;
    if (this.garantia) {
      this.valorExtras += this.subtotal * 0.10;
      total += this.subtotal * 0.10;
    }
    if (this.embrulho) {
      total += 15.00;
    }

    this.totalEstimado = total;
  }

  podeFinalizar() {
    return this.itens.length > 0 && this.freteSelecionado && this.pagamentoSelecionado;
  }

  finalizarCompra() {
    const pedido = {
      itens: this.itens,
      metodoPagamento: this.pagamentoSelecionado.tipo, 
      tipoFrete: this.freteSelecionado.tipo, 
      cep: this.cep,
      adicionarGarantia: this.garantia,
      adicionarEmbrulho: this.embrulho
    };

    this.api.finalizarPedido(pedido).subscribe({
      next: (res: any) => {
        alert(res.mensagem || 'Pedido realizado!');
        this.cart.limpar();
        this.router.navigate(['/']);
      },
      error: (err) => {
        alert('Erro ao processar: ' + (err.error?.mensagem || 'Erro desconhecido'));
      }
    });
  }
}