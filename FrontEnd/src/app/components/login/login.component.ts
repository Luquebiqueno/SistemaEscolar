import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsuarioAutenticado } from 'src/app/models/usuario-autenticado';
import { UsuarioLogin } from 'src/app/models/usuario-login';
import { AutenticacaoService } from 'src/app/services/autenticacao.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form: FormGroup;
  usuarioLogin: UsuarioLogin;

  constructor(private autenticacaoService: AutenticacaoService,
              private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.validarFormulario();
  }

  public validarFormulario() {
    this.form = this.formBuilder.group({
      login: ['', [Validators.required]],
      senha: ['', [Validators.required]]
    });
  }

  public login() {
    debugger;
    if(this.form.invalid) {
      alert('Dados inválidos.');
      return null;
    }
    this.usuarioLogin = this.form.value;
    return this.autenticacaoService.getAutenticacao(this.usuarioLogin).subscribe((usuarioAutenticado: UsuarioAutenticado) => { 
      if(usuarioAutenticado && usuarioAutenticado.accessToken){  
        localStorage['usuarioAutenticado'] = JSON.stringify(usuarioAutenticado);          
      }

      alert(usuarioAutenticado.message);
    });
  }

}
