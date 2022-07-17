using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Curso
{
    public class CursoCreacionDTO
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool obligatorio { get; set; }
    }
}