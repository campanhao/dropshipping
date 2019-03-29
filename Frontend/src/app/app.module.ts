import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { routing } from './app.routing';
import { UsuarioService } from './_services/usuario.service';
import { CabecalhoComponent } from './cabecalho/cabecalho.component';
import { RodapeComponent } from './rodape/rodape.component';
import { ProdutoService } from './_services/produto.service';
import { FormsModule } from '@angular/forms';
import { CatalogoComponent } from './catalogo/catalogo.component';
import { CarrinhoComponent } from './carrinho/carrinho.component';
import { CarrinhoService } from './_services/carrinho.service';
import { PagerService } from './_services/pager.service';
import { JwPaginationComponent } from 'jw-angular-pagination';
import { ProdutoComponent } from './produto/produto.component';
import { PedidoComponent } from './pedido/pedido.component';
import { PedidoService } from './_services/pedido.service';
import { PedidoItemComponent } from './pedido/pedido-item/pedido-item.component';
import { CategoriaService } from './_services/categoria.service';
import { AlertComponent } from './_directives/alert.component';
import { AuthGuard } from './_guards/auth.guard';
import { JwtInterceptor } from './_helpers/jwt.interceptor';
import { ErrorInterceptor } from './_helpers/error.interceptor';
import { AlertService } from './_services/alert.service';
import { AuthenticationService } from './_services/authentication.service';
import { LoginComponent } from './login/login.component';
import { CompraComponent } from './compra/compra.component';
@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        routing,
        FormsModule,
        NgbModule.forRoot()
    ],
    declarations: [
        AppComponent,
        AlertComponent,
        LoginComponent,
        CabecalhoComponent,
        RodapeComponent,
        CatalogoComponent,
        CarrinhoComponent,
        CompraComponent,
        JwPaginationComponent,
        ProdutoComponent,
        PedidoComponent,
        PedidoItemComponent],
    providers: [
        AuthGuard,
        AlertService,
        AuthenticationService,
        CarrinhoService,
        UsuarioService,
        ProdutoService,
        PagerService,
        PedidoService,
        CategoriaService,
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }