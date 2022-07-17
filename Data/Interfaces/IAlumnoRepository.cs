using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Context;

namespace Data.Interfaces
{
    public interface IAlumnoRepository
    {
        public Task<int> registrarAlumno(AP_Alvarez_Ricardo_Alumno model);
        public IQueryable<AP_Alvarez_Ricardo_Alumno> obtenerAlumno(int id);
        public Task actualizarAlumno(AP_Alvarez_Ricardo_Alumno model);
        public Task anularAlumno(int id);
        public Task<List<AP_Alvarez_Ricardo_Alumno>> obtenerAlumnos();
    }
}