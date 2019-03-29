import { PedidoItem } from "./pedido-item";

export class Pedido {
    itens: PedidoItem[];
    usuarioEnderecoId:number;
    formaPagamentoId:number;
    valorTotal: number;
}