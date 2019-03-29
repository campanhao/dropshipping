import { Component, OnInit } from '@angular/core';
import { PedidoService } from '../_services/pedido.service';
import { DetalhePedido } from '../_models/detalhe-pedido';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedido.component.html',
  styleUrls: ['./pedido.component.css']
})
export class PedidoComponent implements OnInit {

  constructor(private pedidoService: PedidoService) { }

  public pedidos: DetalhePedido[] = [];
  pageOfItems: DetalhePedido[];

  ngOnInit() {
    this.getPedidos();
  }

  onChangePage(pageOfItems: DetalhePedido[]) {
    this.pageOfItems = pageOfItems;
}

  getPedidos() {
    this.pedidoService.selecionar().subscribe(retorno => {
      this.pedidos = retorno;
    });
  }
}
