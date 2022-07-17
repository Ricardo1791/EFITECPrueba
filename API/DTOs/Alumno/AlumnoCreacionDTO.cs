using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Alumno
{
    public class AlumnoCreacionDTO
    {
        public string apellidos { get; set; }
        public string nombres { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string sexo { get; set; }
    }
}