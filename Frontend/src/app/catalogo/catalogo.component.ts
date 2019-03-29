import { Component, OnInit } from '@angular/core';
import { Produto } from '../_models/produto';
import { ProdutoService } from '../_services/produto.service';
import { Observable } from 'rxjs';
import { CategoriaService } from '../_services/categoria.service';
import { Categoria } from '../_models/categoria';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
  selector: 'app-catalogo',
  templateUrl: './catalogo.component.html',
  styleUrls: ['./catalogo.component.css']
})
export class CatalogoComponent implements OnInit {

  public constructor(private produtoService: ProdutoService,
    private authenticationService: AuthenticationService,private categoriaService: CategoriaService) {
  }

  isCollapsed = true;
    items: Produto[];
    valor:string;
    pageOfItems: Produto[];
    categorias: Categoria[] = [];

  onChangePage(pageOfItems: Produto[]) {
    this.pageOfItems = pageOfItems;
    window.scrollTo(0, 0);
}

  public ngOnInit(): void {
    this.usuarioLogado = this.authenticationService.usuarioLogado;
    this.selecionarTodos();
    this.getCategorias();
  }

  selecionarTodos(): any {
    this.produtoService.selecionarTodos().subscribe(retorno => {
      this.items = retorno;
    });
  }

  getCategorias(): any {
    this.categoriaService.get().subscribe(retorno => {
      this.categorias = retorno;
    });
  }

  pesquisar() {
    if (!this.valor) {
      this.selecionarTodos();
    }
    else {
      this.produtoService.pesquisar(this.valor).subscribe(retorno => {
        this.items = retorno;
      });
    }
  }

  selecionarPorCategoria(categoriaId:number) {
      this.valor = null;
      this.produtoService.selecionarPorCategoria(categoriaId).subscribe(retorno => {
        this.items = retorno;
      });
  }

  usuarioLogado: Observable<string>;

}
