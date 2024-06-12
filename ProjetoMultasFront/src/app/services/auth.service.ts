import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private usuarioAutenticadoPortal: boolean = false;
  private token: any;
  private id: any;
  private tipoUser: any;

  constructor(private httpClient: HttpClient) {}

  checkToken() {
    return Promise.resolve(true);
  }
  UsuarioAutenticado(status: boolean) {
    //guarda se o usuario esta autenticado
    localStorage.setItem('usuarioAutenticadoPortal', JSON.stringify(status));
    this.usuarioAutenticadoPortal = status;
  }

  UsuarioEstaAutenticado(): Promise<boolean> {
    this.usuarioAutenticadoPortal =
      localStorage.getItem('usuarioAutenticadoPortal') == 'true';
    return Promise.resolve(this.usuarioAutenticadoPortal);
  }

  setToken(token: string) {
    localStorage.setItem('token', 'Bearer ' + token);
    this.token = 'Bearer ' + token;
  }
  setId(id: string) {
    localStorage.setItem('id', id);
    this.id = id;
  }
  setTipoUser(tipoUser: string) {
    localStorage.setItem('tipoUser', tipoUser);
    this.tipoUser = tipoUser;
  }

  get getToken() {
    this.token = localStorage.getItem('token');
    return this.token;
  }

  get getId() {
    this.id = localStorage.getItem('id');
    return this.id;
  }

  get getTipoUser() {
    this.tipoUser = localStorage.getItem('tipoUser');
    return this.tipoUser;
  }

  limparToken() {
    this.token = null;
    this.id = null;
    this.tipoUser = null;
  }

  limparDadosUsuario() {
    this.UsuarioAutenticado(false);
    this.limparToken();
    localStorage.clear();
    sessionStorage.clear();
  }
}
