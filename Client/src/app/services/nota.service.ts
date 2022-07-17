import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { NotaDTO } from '../models/Nota.model';

@Injectable({
  providedIn: 'root'
})
export class NotaService {
  url: string = environment.ApiUrl;

  constructor(private http: HttpClient) { }

  obtenerNotas(){
    return this.http.get<any[]>(this.url + 'nota');
  }

  obtenerNota(id: number){
    return this.http.get<NotaDTO>(this.url + 'nota/' + id);
  }

  registrarNota(model: NotaDTO){
    return this.http.post(this.url + 'nota', model);
  }

  actualizarNota(model: NotaDTO){
    return this.http.put(this.url + 'nota', model);
  }

  anularNota(id: number){
    return this.http.put(this.url + 'nota/anular/' + id, {});
  }

  comboalumnos(){
    return this.http.get<any[]>(this.url + 'nota/comboalumno');
  }

  combocurso(){
    return this.http.get<any[]>(this.url + 'nota/combocurso');
  }
}
