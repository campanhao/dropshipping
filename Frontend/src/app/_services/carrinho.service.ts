import { Produto } from "../_models/produto";
import { CarrinhoItem } from "../_models/carrinhoItem";
import { Observable, BehaviorSubject } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Injectable } from "@angular/core";
import { Pedido } from "../_models/pedido";
import { FormaPagamento } from "../_models/forma-pagamento";

@Injectable()
export class CarrinhoService {

    items: CarrinhoItem[] = []
    private quantidade = new BehaviorSubject<number>(this.obterQuantidade());

    constructor(private http: HttpClient) { }

    clear() {
        this.items = [];
        this.quantidade.next(this.obterQuantidade());
    }

    get quantidadeItens() {
        return this.quantidade.asObservable();
    }

    getFormasPagamento(): Observable<FormaPagamento[]> {
        return this.http.get<FormaPagamento[]>(`${environment.apiUrl}/formaspagamento`);
    }

    obterQuantidade(): number {
        if (this.items.length == 0)
            return 0;
        else
            return this.items.map(item => item.quantidade).reduce((prev, value) => prev + value, 0);
    }

    addItem(item: Produto) {
        let foundItem = this.items.
            find(mItem => mItem.produto.produtoId == item.produtoId)
        if (foundItem) {
            this.increaseQty(foundItem)
        } else {
            this.items.push(new CarrinhoItem(item))
        }
        this.quantidade.next(this.obterQuantidade());
    }

    increaseQty(item: CarrinhoItem) {
        item.quantidade = item.quantidade + 1;
        this.quantidade.next(this.obterQuantidade());
    }

    decreaseQty(item: CarrinhoItem) {
        item.quantidade = item.quantidade - 1
        if (item.quantidade == 0) {
            this.removeItem(item)
        }
        this.quantidade.next(this.obterQuantidade());
    }


    removeItem(item: CarrinhoItem) {
        this.items.splice(this.items.indexOf(item, 1));
        this.quantidade.next(this.obterQuantidade());
    }

    total(): number {
        return this.items.
            map(item => item.value()).reduce((prev, value) => prev + value, 0)
    }

    salvar(pedido:Pedido): Observable<string> {
        return this.http.post<string>(`${environment.apiUrl}/pedidos`, pedido);
    }


}