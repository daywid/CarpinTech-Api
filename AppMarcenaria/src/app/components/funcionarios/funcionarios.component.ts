import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Funcionario } from 'src/app/Funcionario';
import { FuncionariosService } from 'src/app/funcionarios.service';

@Component({
  selector: 'app-funcionarios',
  templateUrl: './funcionarios.component.html',
  styleUrls: ['./funcionarios.component.css']
})
export class FuncionariosComponent implements OnInit{
  formulario!: FormGroup;  // Alteração aqui
  tituloFormulario: string = '';
  meuFuncionario: any;
  funcionario: any;

  constructor(private formBuilder: FormBuilder, private funcionariosService: FuncionariosService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Funcionario';
    this.formulario = this.formBuilder.group({
      nome: [null],
      funcao: [null],
      salario: [null],
      horasTrabalhadas: [null],
  });
}

  enviarFormulario(): void {
    const funcionario: Funcionario = this.formulario.value;
    const observer: Observer<Funcionario> = {
      next(_result): void {alert('Funcionario salvo com sucesso.');
    },
    error(_error): void {
      alert('Erro ao salvar!');
    },
    complete(): void {
    },
  };
  if (funcionario.id && !isNaN(Number(funcionario.id))) {
    this.funcionariosService.atualizar(funcionario).subscribe(observer);
  } else {
    this.funcionariosService.cadastrar(funcionario).subscribe(observer);}}

}
