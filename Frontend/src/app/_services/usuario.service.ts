import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { UsuarioEndereco } from '../_models/usuario-endereco';
import { Observable } from 'rxjs';

@Injectable()
export class UsuarioService {
    constructor(private http: HttpClient) { }

    getEndereco(): Observable<UsuarioEndereco[]> {
        return this.http.get<UsuarioEndereco[]>(`${environment.apiUrl}/usuarios/enderecos`);
    }
}