import { Routes } from '@angular/router';
import { ProdutoListaComponent } from './components/produto-lista/produto-lista';
import { CarrinhoComponent } from './components/carrinho/carrinho';
import { CheckoutComponent } from './components/checkout/checkout';

export const routes: Routes = [
  { path: '', component: ProdutoListaComponent },
  { path: 'carrinho', component: CarrinhoComponent },
  { path: 'checkout', component: CheckoutComponent },
  { path: '**', redirectTo: '' }
];