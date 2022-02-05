import { Component, OnInit } from '@angular/core';
import { Aluno } from 'src/app/models/aluno';
import { AlunoService } from 'src/app/services/aluno.service';

@Component({
  selector: 'app-aluno-list',
  templateUrl: './aluno-list.component.html',
  styleUrls: ['./aluno-list.component.css']
})
export class AlunoListComponent implements OnInit {

  public alunos: Aluno[];

  constructor(private alunoService: AlunoService) { }

  ngOnInit(): void {
    this.getAluno();
  }

  getAluno(){
    this.alunoService.getAluno().subscribe((response: Aluno[])=> {
      this.alunos = response
      }
    );  
  }

  public deleteAluno($event: any, id: number) {
    $event.preventDefault();
    if (confirm('Deseja remover este aluno?')) {
      this.alunoService.deleteAluno(id.toString()).subscribe(
        response => {
          this.getAluno();
        }
      );
    }
  }

}
