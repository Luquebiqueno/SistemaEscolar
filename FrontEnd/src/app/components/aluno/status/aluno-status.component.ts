import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AlunoStatus } from 'src/app/models/aluno-status';
import { AlunoService } from 'src/app/services/aluno.service';

@Component({
  selector: 'app-aluno-status',
  templateUrl: './aluno-status.component.html',
  styleUrls: ['./aluno-status.component.css']
})
export class AlunoStatusComponent implements OnInit {

  public alunoStatus: AlunoStatus;

  constructor(private route: ActivatedRoute, private alunoService: AlunoService) { }

  ngOnInit(): void {
    this.getAlunoStatus()
  }


  getAlunoStatus() {
    let id = this.route.snapshot.paramMap.get('id');
    this.alunoService.getAlunoStatus(id).subscribe((response: AlunoStatus) =>{
      this.alunoStatus = response
    });
  }

}
