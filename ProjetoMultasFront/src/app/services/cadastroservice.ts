import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environment';
import { Cadastro } from '../models/Cadastro';

@Injectable({ providedIn: 'root' })
export class CadastroService {
  constructor(private httpClient: HttpClient) {}

  private readonly baseUrl = environment['endPoint'];

  AdicionarUsuario(cadastro: Cadastro) {
    return this.httpClient.post(`${this.baseUrl}/AdicionarUsuario`, cadastro, {
      responseType: 'text',
    });
  }
}
