import { Produto } from "./produto";

export class CarrinhoItem {

    constructor(public produto: Produto,
        public quantidade: number = 1) {

    }

    value(): number {
        return this.produto.preco * this.quantidade;
    }
}