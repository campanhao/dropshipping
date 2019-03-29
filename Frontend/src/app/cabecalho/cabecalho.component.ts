import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { CarrinhoService } from '../_services/carrinho.service';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
  selector: 'app-cabecalho',
  templateUrl: './cabecalho.component.html',
  styleUrls: ['./cabecalho.component.css']
})
export class CabecalhoComponent implements OnInit {

  isCollapsed = true;
  usuarioLogado$: Observable<string>;
  quantidade$ : Observable<number>;
 
  constructor(private router : Router,private authenticationService: AuthenticationService, 
    private carrinhoService: CarrinhoService) { }

  ngOnInit() {
    this.usuarioLogado$ = this.authenticationService.usuarioLogado;
    this.quantidade$ = this.carrinhoService.quantidadeItens;
  }

  sair(){
    this.authenticationService.sair();
    this.carrinhoService.clear();
    this.router.navigate(['/']);
  }


}
