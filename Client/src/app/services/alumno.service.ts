import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AlumnoDTO } from '../models/Alumno.model';

@Injectable({
  providedIn: 'root'
})
export class AlumnoService {
  url: string = environment.ApiUrl;
  
  constructor(private http: HttpClient) { }

  obtenerAlumnos(){
    return this.http.get<any[]>(this.url + 'Alumno');
  }

  registrarAlumno(model: AlumnoDTO){
    return this.http.post(this.url + 'Alumno', model);
  }

  actualizarAlumno(model: AlumnoDTO){
    return this.http.put(this.url + 'Alumno', model);
  }

  anularAlumno(id: number){
    return this.http.put(this.url + 'Alumno/anular/' + id, {});
  }
}
