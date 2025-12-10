import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from './components/navbar/navbar';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, NavbarComponent],
  template: `
    <div class="d-flex flex-column min-vh-100">
      
      <app-navbar></app-navbar>

      <main class="flex-grow-1">
        <router-outlet></router-outlet>
      </main>

      <footer class="bg-dark text-light py-4 mt-auto border-top border-secondary">
        <div class="container">
          <div class="row align-items-center">
            
            <div class="col-md-6 text-center text-md-start mb-3 mb-md-0">
              <h5 class="fw-bold text-white mb-1"><i class="bi bi-cpu-fill me-2"></i>TechStore</h5>
              <small class="text-white-50">&copy; 2025 Todos os direitos reservados - Marcos Calera.</small>
            </div>

            <div class="col-md-6 text-center text-md-end">
              <div class="d-flex justify-content-center justify-content-md-end gap-3 mb-2">
                <a href="#" class="text-white-50 text-decoration-none hover-white">Privacidade</a>
                <a href="#" class="text-white-50 text-decoration-none hover-white">Termos</a>
                <a href="#" class="text-white-50 text-decoration-none hover-white">Suporte</a>
              </div>
              <div>
                <a href="#" class="text-white me-3"><i class="bi bi-instagram"></i></a>
                <a href="#" class="text-white me-3"><i class="bi bi-twitter-x"></i></a>
                <a href="#" class="text-white"><i class="bi bi-linkedin"></i></a>
              </div>
            </div>

          </div>
        </div>
      </footer>

    </div>
  `,
  styles: [`
    .hover-white:hover {
      color: #fff !important;
      transition: color 0.2s;
    }
  `]
})
export class AppComponent {}