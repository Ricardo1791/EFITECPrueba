using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Context;

namespace Data.Interfaces
{
    public interface ICursoRepository
    {
        public Task<int> registrarCurso(AP_Alvarez_Ricardo_Curso model);
        public IQueryable<AP_Alvarez_Ricardo_Curso> obtenerCurso(int id);
        public Task actualizarCurso(AP_Alvarez_Ricardo_Curso model);
        public Task anularCurso(int id);
        public Task<List<AP_Alvarez_Ricardo_Curso>> obtenerCursos();
    }
}