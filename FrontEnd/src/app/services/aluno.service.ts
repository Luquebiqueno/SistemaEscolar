import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Aluno } from '../models/aluno';
import { AlunoStatus } from '../models/aluno-status';

@Injectable({
  providedIn: 'root'
})
export class AlunoService {

  url= environment.host + 'Aluno'
  
  constructor(private http: HttpClient) { }

  public getAluno() : Observable<Aluno[]> {
    return this.http.get<Aluno[]>(this.url);
  }

  public getAlunoById(id:string) : Observable<Aluno> {
    return this.http.get<Aluno>(this.url + '/' + id);
  }

  public getAlunoStatus(id:string) : Observable<AlunoStatus> {
    return this.http.get<AlunoStatus>(this.url + '/AlunoStatus/' + id);
  }

  public createAluno(model: any) {
    return this.http.post(this.url, model);
  }

  public updateAluno(id:string, model:Aluno) : Observable<Aluno>{
    return this.http.put<Aluno>(this.url + '/' + id, model);
  }

  public deleteAluno(id:string) : Observable<any> {
    return this.http.delete(this.url + '/DeleteAluno/' + id);
  }
}
