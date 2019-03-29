import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { environment } from '../../environments/environment';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable()
export class AuthenticationService {
    constructor(private http: HttpClient) { }

    private usuario = new BehaviorSubject<string>(this.obterUsuario());

    get usuarioLogado(){
        return this.usuario.asObservable();
    }

    login(email: string, senha: string) {
        return this.http.post<any>(`${environment.apiUrl}/logins/usuario`, { email: email, senha: senha })
            .pipe(map(token => {
                // login successful if there's a jwt token in the response
                if (token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('token', token);
                }
                this.usuario.next(this.obterUsuario());
                return token;
            }))

    }

    sair() {
        // remove user from local storage to log user out
        localStorage.removeItem('token');
        this.usuario.next(null);
    }

    obterUsuario():string{
        let nome:string = null;
        let token:string;
        if (localStorage.getItem('token')) {
            token = localStorage.getItem('token');
            let jwtData = token.split('.')[1]
            let decodedJwtJsonData = window.atob(jwtData)
            let decodedJwtData = JSON.parse(decodedJwtJsonData)
           
            nome = decodedJwtData.nome;
        }  
        return nome;
    }
}