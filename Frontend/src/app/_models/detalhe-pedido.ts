
export class DetalhePedido {
    pedidoEntrega: PedidoEntrega;
    data: Date;
    valorTotal: number;
    pedidoItens: PedidoItens[];
}

export class PedidoEntrega {
    logradouro: string;
    numero: string;
    complemento: string;
    bairro: string;
    cidade: string;
    estado: string;
    cep: string;
}

export class PedidoItens {
    nomeProduto: string;
    quantidade: number;
    precoUnitario: number;
    PedidoItemFornecedor: PedidoItemFornecedor;
}

export class PedidoItemFornecedor {
    statusNome: string;
    codPedidoItemFornec: string;
}