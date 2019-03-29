import { Component, OnInit, Input } from '@angular/core';
import { Produto } from '../_models/produto';
import { CarrinhoService } from '../_services/carrinho.service';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {

  @Input() produto: Produto;

  constructor(private carrinhoService: CarrinhoService) { }

  ngOnInit() {
  }

  addItem(produto:Produto){
    this.carrinhoService.addItem(produto);
  }

}