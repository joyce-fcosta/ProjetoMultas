import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environment';

@Injectable({ providedIn: 'root' })
export class LoginService {
  constructor(private httpClient: HttpClient) {}

  private readonly baseUrl = environment['endPoint'];
  login(usuario: any) {
    // console.log(usuario);
    return this.httpClient.post(
      `http://localhost:5018/api/CreateToken`,
      usuario,
      {
        responseType: 'text',
      }
    );
  }
  loginTest(usuario: any) {
    // console.log(usuario);
    return this.httpClient.post(
      `http://localhost:5018/api/CreateTokenTeste`,
      usuario,
      {
        responseType: 'text',
      }
    );
  }
}
