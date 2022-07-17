using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Nota
{
    public class NotaCreacionDTO
    {
        public int idalumno { get; set; }
        public int idcurso { get; set; }
        public decimal practica1 { get; set; }
        public decimal practica2 { get; set; }
        public decimal practica3 { get; set; }
        public decimal parcial { get; set; }
        public decimal final { get; set; }
    }
}