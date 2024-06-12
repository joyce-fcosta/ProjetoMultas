import { Component } from '@angular/core';
import { CadastroMultasComponent } from '../cadastro-multas/cadastro-multas.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  standalone: true,
  imports: [CadastroMultasComponent],
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent {}
