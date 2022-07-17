using System;
using System.Collections.Generic;

#nullable disable

namespace data.Context
{
    public partial class AP_Alvarez_Ricardo_Nota
    {
        public int id { get; set; }
        public int idalumno { get; set; }
        public int idcurso { get; set; }
        public decimal? practica1 { get; set; }
        public decimal? practica2 { get; set; }
        public decimal? practica3 { get; set; }
        public decimal? parcial { get; set; }
        public decimal? final { get; set; }
        public bool? estado { get; set; }

        public virtual AP_Alvarez_Ricardo_Alumno idalumnoNavigation { get; set; }
        public virtual AP_Alvarez_Ricardo_Curso idcursoNavigation { get; set; }
    }
}
