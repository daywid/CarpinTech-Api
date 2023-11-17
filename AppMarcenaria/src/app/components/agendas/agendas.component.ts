import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AgendasService } from 'src/app/models/agenda/agendas.service';
import { Agenda } from 'src/app/models/agenda/Agenda';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-agendas',
  templateUrl: './agendas.component.html',
  styleUrls: ['./agendas.component.css']
})
export class AgendasComponent implements OnInit {
  formulario!: FormGroup;
  tituloFormulario: string = '';
  minhaAgenda: any;
  agenda: any;
  agendasList: Agenda[] = [];  // Adicione esta propriedade

  constructor(private formBuilder: FormBuilder, private agendasService: AgendasService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Agenda';
    this.formulario = this.formBuilder.group({
      descricao: [null],
      data: [null],
      tipo: [null],
      funcionarioId: [null],
    });
  }

  enviarFormulario(): void {
    const agenda: Agenda = this.formulario.value;
    const observer: Observer<Agenda> = {
      next(_result): void {
        alert('Agenda salva com sucesso.'); // Atualiza a lista após salvar
      },
      error(_error): void {
        alert('Erro ao salvar!');
      },
      complete(): void {
      },
    };

    if (agenda.id && !isNaN(Number(agenda.id))) {
      this.agendasService.atualizar(agenda).subscribe(observer);
      this.listarAgendas();
    } else {
      this.agendasService.cadastrar(agenda).subscribe(observer);
      this.listarAgendas();
    }
  }

  listarAgendas(): void {
    this.agendasService.listar().subscribe(
      (agendas) => {
        console.log('Agendas listadas com sucesso:', agendas);
        this.agendasList = agendas;
      },
      (error) => {
        console.error('Erro ao listar agendas:', error);
        // Trate o erro conforme necessário
      }
    );
  }


  atualizarAgendas(): void {
    // Lógica para atualizar agendas
    // Exemplo: Atualizar todas as agendas selecionadas na lista
    for (const agenda of this.agendasList) {
      this.agendasService.atualizar(agenda).subscribe(
        (_result) => {
          console.log('Agenda atualizada com sucesso:', agenda);
        },
        (error) => {
          console.error('Erro ao atualizar agenda:', error);
          // Trate o erro conforme necessário
        }
      );
    }
    this.listarAgendas(); // Atualiza a lista após as atualizações
  }

  // deletarAgendas(): void {
  //   // Lógica para deletar agendas
  //   // Exemplo: Deletar todas as agendas selecionadas na lista
  //   for (const agenda of this.agendasList) {
  //     this.agendasService.excluir(agenda.id).subscribe(
  //       (_result) => {
  //         console.log('Agenda deletada com sucesso:', agenda);
  //       },
  //       (error) => {
  //         console.error('Erro ao deletar agenda:', error);
  //         // Trate o erro conforme necessário
  //       }
  //     );
  //   }
  //   this.listarAgendas(); // Atualiza a lista após as exclusões
  // }

  deletarAgenda(id: number): void {
    // Confirmar a exclusão antes de prosseguir
    const confirmarExclusao = confirm('Tem certeza que deseja excluir esta agenda?');

    if (confirmarExclusao) {
      // Chamar o serviço para deletar a agenda
      this.agendasService.excluir(id).subscribe(
        (_result) => {
          console.log('Agenda deletada com sucesso:', id);
          // Atualizar a lista após a exclusão
          this.listarAgendas();
        },
        (error) => {
          console.error('Erro ao deletar agenda:', error);
          // Trate o erro conforme necessário
        }
      );
    }
  }











}
