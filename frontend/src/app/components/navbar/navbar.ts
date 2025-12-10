import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterModule],
  template: `
    <nav class="navbar navbar-expand-lg navbar-custom sticky-top">
      <div class="container">
        <a class="navbar-brand d-flex align-items-center gap-2" routerLink="/">
          <i class="bi bi-cpu-fill fs-3"></i>
          <span>TechStore</span>
        </a>
        
        <button class="navbar-toggler border-0" type="button" data-bs-toggle="collapse" data-bs-target="#navbarContent">
          <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarContent">
          <ul class="navbar-nav me-auto mb-2 mb-lg-0 ms-lg-4">
            <li class="nav-item">
              <a class="nav-link" routerLink="/" routerLinkActive="active" [routerLinkActiveOptions]="{exact: true}">Home</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">Lançamentos</a>
            </li>
          </ul>
          
          <div class="d-flex align-items-center gap-3">
            <a routerLink="/carrinho" class="btn btn-outline-dark border-0 position-relative rounded-circle p-2" style="width: 45px; height: 45px;">
              <i class="bi bi-bag fs-5"></i>
              <span class="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger border border-light"
                    *ngIf="(cart.itens$ | async)?.length as count">
                {{ count }}
              </span>
            </a>
          </div>
        </div>
      </div>
    </nav>
  `
})
export class NavbarComponent {
  cart = inject(CartService);
}