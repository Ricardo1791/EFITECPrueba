import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { CursoDTO } from '../models/Curso.model';


@Injectable({
  providedIn: 'root'
})
export class CursoService {
  url: string = environment.ApiUrl;
  
  constructor(private http: HttpClient) { }

  obtenerCursos(){
    return this.http.get<any[]>(this.url + 'Curso');
  }

  registrarCurso(model: CursoDTO){
    return this.http.post(this.url + 'Curso', model);
  }

  actualizarCurso(model: CursoDTO){
    return this.http.put(this.url + 'Curso', model);
  }

  anularCurso(id: number){
    return this.http.put(this.url + 'Curso/anular/' + id,  {});
  }
}
