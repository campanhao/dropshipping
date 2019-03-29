import { Component, OnInit, Input } from '@angular/core';
import { DetalhePedido } from 'src/app/_models/detalhe-pedido';

@Component({
  selector: 'app-pedido-item',
  templateUrl: './pedido-item.component.html',
  styleUrls: ['./pedido-item.component.css']
})
export class PedidoItemComponent implements OnInit {

  @Input() pedido: DetalhePedido;

  constructor() { }

  ngOnInit() {
  }

}
