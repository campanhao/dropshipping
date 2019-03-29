import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { Produto } from '../_models/produto';
import { Observable } from 'rxjs';

@Injectable()
export class ProdutoService {

    private products: Observable<Produto[]>;
    private models: Produto[] = [];

    constructor(private http: HttpClient) { }

    selecionarTodos():Observable<Produto[]> {
        return this.http.get<Produto[]>(`${environment.apiUrl}/produtos`);
    }

    pesquisar(nome:string):Observable<Produto[]> {
        return this.http.get<Produto[]>(`${environment.apiUrl}/produtos/pesquisar?nome=${nome}`);
    }
    selecionarPorCategoria(categoriaId:number):Observable<Produto[]> {
        return this.http.get<Produto[]>(`${environment.apiUrl}/produtos/categoria?categoriaId=${categoriaId}`);
    }
}