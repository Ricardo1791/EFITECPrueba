import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CursoDTO } from 'src/app/models/Curso.model';
import { CursoService } from 'src/app/services/curso.service';

@Component({
  selector: 'app-curso',
  templateUrl: './curso.component.html',
  styleUrls: ['./curso.component.css']
})
export class CursoComponent implements OnInit {
  modalRef?: BsModalRef;
  model = new CursoDTO();
  lista: any[] = [];
  nuevo = true;

  constructor(private cursoService: CursoService, private modalService: BsModalService) { }

  ngOnInit(): void {
    this.listarCursos();
  }

  listarCursos(){
    this.cursoService.obtenerCursos().subscribe(data => this.lista = data);
  }

  NuevoCurso(template: TemplateRef<any>) {
    this.model = new CursoDTO();
    this.nuevo = true;
    this.modalRef = this.modalService.show(template, {class: 'modal-lg'});
  }

  registrarCurso(){
    this.cursoService.registrarCurso(this.model).subscribe((rsp: any) => {
      this.model.id = rsp;
      this.lista.push(this.model);
      this.modalService.hide();
    });
  }

  anularCurso(model: any, i: number){
    this.cursoService.anularCurso(model.id).subscribe(() => {
      this.lista.splice(i, 1);
    })
  }

  editarCurso(template: TemplateRef<any>, curso: any){
    this.nuevo = false;
    this.model = curso;
    this.modalRef = this.modalService.show(template, {class: 'modal-lg'});
  }
  
  actualizarCurso(){
    this.modalService.hide();
    this.cursoService.actualizarCurso(this.model).subscribe(() => {
      this.listarCursos();
    });
  }

}
