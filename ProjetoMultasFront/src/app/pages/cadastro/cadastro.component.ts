import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validator, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CadastroService } from 'src/app/services/cadastroservice';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css'],
})
export class CadastroComponent {
  constructor(
    public formBuilder: FormBuilder,
    private router: Router,
    private cadastroService: CadastroService
  ) {}

  ngOnInit(): void {
    this.cadastroForm = this.formBuilder.group({
      nome: ['', Validators.required],
      email: ['', Validators.required],
      senha: ['', Validators.required],
    });
  }

  cadastroForm!: FormGroup;
  get dadosForm() {
    return this, this.cadastroForm.controls;
  }

  cadastrarUsuario() {
    const cadastro = this.cadastroForm.getRawValue();

    this.cadastroService.AdicionarUsuario(cadastro).subscribe({
      next: (result) => {
        alert(result);
        this.router.navigate(['/login']);
      },
      error: (error) => {
        alert('Ocorreu um erro');
      },
    });
  }
}
