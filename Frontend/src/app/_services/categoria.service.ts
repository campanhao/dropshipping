import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Categoria } from '../_models/categoria';

@Injectable()
export class CategoriaService {
    constructor(private http: HttpClient) { }

    get(): Observable<Categoria[]> {
        return this.http.get<Categoria[]>(`${environment.apiUrl}/categorias`);
    }
}