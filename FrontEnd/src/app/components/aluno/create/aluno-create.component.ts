import { Component, OnInit } from '@angular/core';
import { AlunoService } from 'src/app/services/aluno.service';

@Component({
  selector: 'app-aluno-create',
  templateUrl: './aluno-create.component.html',
  styleUrls: ['./aluno-create.component.css']
})
export class AlunoCreateComponent implements OnInit {

  constructor(private alunoService: AlunoService) { }

  ngOnInit(): void {
  }

  public createAluno(formData: any) : void {
    this.alunoService.createAluno(formData.value).subscribe((response:any) => {
      alert("Salvo com sucesso");
    },
    error => {
      alert("Aconteceu um erro");
    });

  }

}
