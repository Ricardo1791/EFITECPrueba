import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NotaDTO } from 'src/app/models/Nota.model';
import { NotaService } from 'src/app/services/nota.service';

@Component({
  selector: 'app-nota',
  templateUrl: './nota.component.html',
  styleUrls: ['./nota.component.css']
})
export class NotaComponent implements OnInit {
  lista: any[] = [];
  nuevo = true;
  comboalumno: any[] = [];
  combocurso: any[] = [];
  model = new NotaDTO();
  modalRef?: BsModalRef;

  constructor(private notaService: NotaService, private modalService: BsModalService) { }

  ngOnInit(): void {
    this.notaService.comboalumnos().subscribe(data => this.comboalumno = data);
    this.notaService.combocurso().subscribe(data => this.combocurso = data);
    this.listarNotas();
  }

  listarNotas(){
    this.notaService.obtenerNotas().subscribe(data => this.lista = data);
  }

  
  NuevaNota(template: TemplateRef<any>) {
    this.model = new NotaDTO();
    this.nuevo = true;
    this.modalRef = this.modalService.show(template, {class: 'modal-lg'});
  }

  registrarNota(){
    this.notaService.registrarNota(this.model).subscribe((rsp: any) => {
      this.model.id = rsp;
      this.lista.push(this.model);
      this.modalService.hide();
    });
  }

  anularNota(model: any, i: number){
    this.notaService.anularNota(model.id).subscribe(() => {
      this.lista.splice(i, 1);
    })
  }

  editarNota(template: TemplateRef<any>, nota: any){
    this.nuevo = false;
    this.model = nota;
    this.modalRef = this.modalService.show(template, {class: 'modal-lg'});
  }
  
  actualizarNota(){
    this.modalService.hide();
    this.notaService.actualizarNota(this.model).subscribe(() => {
      this.listarNotas();
    });
  }

  calcularPromedio(model: NotaDTO){
    const promedioPracticas = Math.round( ((model.practica1 + model.practica2 + model.practica3) / 3) * 100) / 100;

    const promedio = ( (model.parcial + promedioPracticas + (model.final * 2) ) / 4 ).toFixed(2);

    return promedio;
  }

  cambioAlumno(e: any){
    if (e){
      this.model.alumno = e.text;
      this.model.idalumno = e.value;      
    }else{
      this.model.alumno = null;
      this.model.idalumno = null;
    }
  }

  cambioCurso(e: any){
    if (e){
      this.model.curso = e.text;
      this.model.idcurso = e.value;
    }else{
      this.model.curso = null;
      this.model.idcurso = null;
    }
  }
}
