import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroMultasComponent } from './cadastro-multas.component';

describe('CadastroMultasComponent', () => {
  let component: CadastroMultasComponent;
  let fixture: ComponentFixture<CadastroMultasComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CadastroMultasComponent]
    });
    fixture = TestBed.createComponent(CadastroMultasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
