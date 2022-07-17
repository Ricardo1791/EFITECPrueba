import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlumnoComponent } from './pages/alumno/alumno.component';
import { CursoComponent } from './pages/curso/curso.component';
import { NotaComponent } from './pages/nota/nota.component';

const routes: Routes = [
  {path: 'Alumno', component: AlumnoComponent},
  {path: 'Curso', component: CursoComponent},
  {path: 'Nota', component: NotaComponent},
  { path: '**', pathMatch: 'full', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
