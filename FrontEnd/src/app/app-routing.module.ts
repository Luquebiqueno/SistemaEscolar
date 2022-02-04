import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlunoCreateComponent } from './components/aluno/create/aluno-create.component';
import { AlunoEditComponent } from './components/aluno/edit/aluno-edit.component';
import { AlunoListComponent } from './components/aluno/list/aluno-list.component';
import { AlunoStatusComponent } from './components/aluno/status/aluno-status.component';
import { LoginComponent } from './components/login/login.component';
import { LayoutComponent } from './layout/layout.component';
import { AuthGuard } from './_helpers/auth.guard';

const routes: Routes = [
  { 
    path: '', redirectTo: '/login', pathMatch: 'full'
  },
  { 
    path: 'login', component: LoginComponent
  },
  { 
    path: 'app', component: LayoutComponent, canActivate: [AuthGuard],
    children: [  
      { 
        path: '', redirectTo: 'aluno/list', pathMatch: 'full'
      },
      { 
        path: 'aluno/list', component: AlunoListComponent
      },
      { 
        path: 'aluno/edit/:id', component: AlunoEditComponent
      },
      { 
        path: 'aluno/create', component: AlunoCreateComponent
      },
      { 
        path: 'aluno/status/:id', component: AlunoStatusComponent
      }
    ] 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
