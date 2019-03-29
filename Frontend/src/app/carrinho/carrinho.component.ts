import { Component, OnInit } from '@angular/core';
import { CarrinhoService } from '../_services/carrinho.service';

@Component({
  selector: 'app-carrinho',
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.css']
})


export class CarrinhoComponent implements OnInit {

  constructor(private carrinhoService: CarrinhoService) { }


  ngOnInit() {
    this.items();
  }

  items(): any[] {
    return this.carrinhoService.items;
  }

  total(): number {
    return this.carrinhoService.total();
  }

  clear() {
    this.carrinhoService.clear()
  }

  removeItem(item: any) {
    this.carrinhoService.removeItem(item)
  }

  addItem(item: any) {
    this.carrinhoService.addItem(item)
  }

  increaseQty(item: any) {
    this.carrinhoService.increaseQty(item)
  }

  decreaseQty(item: any) {
    this.carrinhoService.decreaseQty(item)
  }
}
