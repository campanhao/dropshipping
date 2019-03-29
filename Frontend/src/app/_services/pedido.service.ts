import { Observable, BehaviorSubject } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Injectable } from "@angular/core";
import { Pedido } from "../_models/pedido";
import { DetalhePedido } from "../_models/detalhe-pedido";

@Injectable()
export class PedidoService {

    constructor(private http: HttpClient) { }

    selecionar():Observable<DetalhePedido[]>{
        return this.http.get<DetalhePedido[]>(`${environment.apiUrl}/pedidos`);
    }

    salvar(pedido: Pedido): Observable<string> {
        return this.http.post<string>(`${environment.apiUrl}/pedidos`, pedido);
    }
}