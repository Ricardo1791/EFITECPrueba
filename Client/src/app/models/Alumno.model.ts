export class AlumnoDTO {
  id: number;
  apellidos: string;
  nombres: string;
  fecha_nacimiento: Date;
  sexo: string;
  estado: boolean;

  /**
   *
   */
  constructor() {
    this.apellidos = '';
    this.nombres = '';
    this.fecha_nacimiento = new Date();
    this.sexo = 'M';
    this.estado = true;
  }
}
