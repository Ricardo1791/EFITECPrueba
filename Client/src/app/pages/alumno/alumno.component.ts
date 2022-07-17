import { Component, OnInit, TemplateRef } from '@angular/core';
import { AlumnoDTO } from 'src/app/models/Alumno.model';
import { AlumnoService } from 'src/app/services/alumno.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-alumno',
  templateUrl: './alumno.component.html',
  styleUrls: ['./alumno.component.css']
})
export class AlumnoComponent implements OnInit {
  modalRef?: BsModalRef;
  model = new AlumnoDTO();
  lista: any[] = [];
  nuevo = true;

  constructor(private alumnoService: AlumnoService, private modalService: BsModalService) { }

  ngOnInit(): void {
    this.listarAlumnos();
  }

  listarAlumnos(){
    this.alumnoService.obtenerAlumnos().subscribe(data => this.lista = data);
  }

  NuevoAlumno(template: TemplateRef<any>) {
    this.model = new AlumnoDTO();
    this.nuevo = true;
    this.modalRef = this.modalService.show(template, {class: 'modal-lg'});
  }

  registrarAlumno(){
    this.alumnoService.registrarAlumno(this.model).subscribe((rsp: any) => {
      this.model.id = rsp;
      this.lista.push(this.model);
      this.modalService.hide();
    });
  }

  anularAlumno(model: any, i: number){
    this.alumnoService.anularAlumno(model.id).subscribe(() => {
      this.lista.splice(i, 1);
    })
  }

  editarAlumno(template: TemplateRef<any>, alumno: any){
    this.nuevo = false;
    this.model = alumno;
    this.model.fecha_nacimiento = new Date(alumno.fecha_nacimiento);
    this.modalRef = this.modalService.show(template, {class: 'modal-lg'});
  }
  
  actualizarAlumno(){
    this.modalService.hide();
    this.alumnoService.actualizarAlumno(this.model).subscribe(() => {
      this.listarAlumnos();
    });
  }
}
