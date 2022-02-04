import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Aluno } from 'src/app/models/aluno';
import { AlunoService } from 'src/app/services/aluno.service';

@Component({
  selector: 'app-aluno-edit',
  templateUrl: './aluno-edit.component.html',
  styleUrls: ['./aluno-edit.component.css']
})
export class AlunoEditComponent implements OnInit {

  public aluno: Aluno;

  constructor(private route: ActivatedRoute, private alunoService: AlunoService) { }

  ngOnInit(): void {
    this.getAlunoById();
  }

  getAlunoById() {
    let id = this.route.snapshot.paramMap.get('id');
    this.alunoService.getAlunoById(id).subscribe((response: Aluno) =>{
      this.aluno = response
    });
  }

  updateAluno(id: number, model: Aluno) {
    this.alunoService.updateAluno(id.toString(), model).subscribe((response: Aluno) => {
      alert("Aluno Atualizado com sucesso");
    },
    error => {
      alert("Aconteceu um erro");
    });
  } 

}
