using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Context;

namespace Data.Interfaces
{
    public interface INotaRepository
    {
        public Task<int> registrarNota(AP_Alvarez_Ricardo_Nota model);
        public IQueryable<AP_Alvarez_Ricardo_Nota> obtenerNota(int id);
        public Task actualizarNota(AP_Alvarez_Ricardo_Nota model);
        public Task anularNota(int id);
        public Task<string> obtenerNotas();
        public Task<string> comboAlumnos();
        public Task<string> comboCursos();
    }
}