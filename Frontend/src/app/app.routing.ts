import { Routes, RouterModule } from '@angular/router';
import { CatalogoComponent } from './catalogo/catalogo.component';
import { CarrinhoComponent } from './carrinho/carrinho.component';
import { ProdutoComponent } from './produto/produto.component';
import { PedidoComponent } from './pedido/pedido.component';
import { AuthGuard } from './_guards/auth.guard';
import { LoginComponent } from './login/login.component';
import { CompraComponent } from './compra/compra.component';

const appRoutes: Routes = [
    { path: '',redirectTo: '/catalogo', pathMatch: 'full' },
    { path: 'catalogo', component: CatalogoComponent},
    { path: 'login', component: LoginComponent },
    { path: 'produto', component: ProdutoComponent },
    { path: 'carrinho', component: CarrinhoComponent},
    { path: 'pedido', component: PedidoComponent,canActivate: [AuthGuard] },
    { path: 'compra', component: CompraComponent,canActivate: [AuthGuard] },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);