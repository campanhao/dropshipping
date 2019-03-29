import { Component, OnInit } from '@angular/core';
import { CarrinhoService } from '../_services/carrinho.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Pedido } from '../_models/pedido';
import { PedidoItem } from '../_models/pedido-item';
import { UsuarioEndereco } from '../_models/usuario-endereco';
import { FormaPagamento } from '../_models/forma-pagamento';
import { AlertService } from '../_services/alert.service';
import { UsuarioService } from '../_services/usuario.service';

@Component({
  selector: 'app-compra',
  templateUrl: './compra.component.html',
  styleUrls: ['./compra.component.css']
})


export class CompraComponent implements OnInit {

  constructor(
    private carrinhoService: CarrinhoService, private alertService: AlertService,
    private usuarioService: UsuarioService, private modalService: NgbModal) { }


  usuarioEndereco: UsuarioEndereco[];
  formaPagamento: FormaPagamento[];
  mensagem: string;
  btnSim: boolean = false;
  btnNao: boolean = false;
  btnFechar: boolean = false;
  escolhaEndereco: number;
  escolhaFormaPagamento: number;

  ngOnInit() {
    this.items();
    this.getEndereco();
    this.getFormasPagamento();
  }


  items(): any[] {
    return this.carrinhoService.items;
  }
  getEndereco(): any {
    this.usuarioService.getEndereco().subscribe(retorno => {
      this.usuarioEndereco = retorno;
    });
  }
  getFormasPagamento(): any {
    this.carrinhoService.getFormasPagamento().subscribe(retorno => {
      this.formaPagamento = retorno;
    });
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

  open(content) {
    this.mensagem = `Você confirma a efetivação do pedido?`
    this.btnFechar = false;
    this.btnNao = true;
    this.btnSim = true;
    this.modalService.open(content, { centered: true, backdrop : 'static',keyboard : false });
  }

  salvar(content) {
    let pedido = new Pedido();
    pedido.itens = [];
    let carrinho = this.carrinhoService.items;

    carrinho.forEach(item => {
      var pedidoItem = new PedidoItem();
      pedidoItem.quantidade = item.quantidade;
      pedidoItem.produtoId = item.produto.produtoId;
      pedidoItem.precoUnitario = item.produto.preco;
      pedido.itens.push(pedidoItem);
    });
    pedido.valorTotal = this.total();
    pedido.formaPagamentoId = this.escolhaFormaPagamento;
    pedido.usuarioEnderecoId = this.escolhaEndereco;

    this.carrinhoService.salvar(pedido).subscribe(retorno => {
      this.btnFechar = true;
      this.btnNao = false;
      this.btnSim = false;
      this.mensagem = retorno;
      this.carrinhoService.clear();
      this.modalService.open(content, { centered: true,backdrop : 'static',keyboard : false }).result.then(() => {
        this.modalService.dismissAll();
      });
    },
      err => {
        this.alertService.error("Ocorreu um erro durante o processamento do pedido!");
        this.modalService.dismissAll();
        window.scrollTo(0, 0);
      });
  }
}
