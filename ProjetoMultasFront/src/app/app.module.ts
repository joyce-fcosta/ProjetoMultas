import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastroComponent } from './pages/cadastro/cadastro.component';
import { LoginComponent } from './pages/login/login.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import {
  HTTPStatus,
  LoaderInterceptor,
} from 'src/interceptor/loader.interceptor';
import { AuthGuard } from './pages/guards/auth-guard.service';
import { CadastroMultasModule } from './pages/cadastro-multas/cadastro-multas.module';

const RxJS = [LoaderInterceptor, HTTPStatus];

@NgModule({
  declarations: [AppComponent, CadastroComponent, LoginComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [
    AuthGuard,
    RxJS,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
  exports: [CommonModule],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
