import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsuarioLogado } from 'src/app/models/UsuarioLogado';
import { AuthService } from 'src/app/services/auth.service';
import { LoginService } from 'src/app/services/loginservice';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  user!: UsuarioLogado;

  constructor(
    public formBuilder: FormBuilder,
    private route: Router,
    private loginService: LoginService,
    public authService: AuthService
  ) {}

  loginForm!: FormGroup;

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      Email: ['', [Validators.required, Validators.email]],
      Password: ['', [Validators.required]],
    });
  }

  get dadosForm() {
    return this, this.loginForm.controls;
  }

  loginUser() {
    const form = this.loginForm.getRawValue();
    // console.log(form);

    this.loginService.login(form).subscribe({
      next: (dadosUsuario) => {
        let user2: any = dadosUsuario;
        JSON.parse(user2);
        this.user = user2;

        this.authService.setToken(this.user.token);
        this.authService.setId(this.user.id);
        this.authService.setTipoUser(this.user.tipo);
        this.authService.UsuarioAutenticado(true);
        this.route.navigate(['/dashboard']);
      },
      error: (error) => {
        alert('Ocorreu um erro');
        console.log(error);
      },
    });
  }
  //   this.loginService.login(form).subscribe({
  //     next: (dadosUsuario) => {
  //       console.log(dadosUsuario);
  //       let user2: any = dadosUsuario;
  //       this.user = user2;
  //       this.authService.setToken(this.user.token);
  //       this.authService.setId(this.user.id);
  //       this.authService.setTipoUser(this.user.tipo);
  //       this.authService.UsuarioAutenticado(true);
  //       this.route.navigate(['/dashboard']);
  //     },
  //     error: (error) => {
  //       alert('Ocorreu um erro');
  //       console.log(error);
  //     },
  //   });
  // }
}
