import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { AlumnoComponent } from './pages/alumno/alumno.component';
import { CursoComponent } from './pages/curso/curso.component';
import { HomeComponent } from './pages/home/home.component';
import { NotaComponent } from './pages/nota/nota.component';

const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'Alumno', component: AlumnoComponent, canActivate: [AuthGuard]},
  { path: 'Curso', component: CursoComponent, canActivate: [AuthGuard]},
  { path: 'Nota', component: NotaComponent, canActivate: [AuthGuard]},
  { path: '**', pathMatch: 'full', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
