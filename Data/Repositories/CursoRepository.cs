using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Context;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly DatabaseContext db;

        public CursoRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task actualizarCurso(AP_Alvarez_Ricardo_Curso model)
        {
            db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task anularCurso(int id)
        {
            var model = await db.AP_Alvarez_Ricardo_Curso.FindAsync(id);
            model.estado = false;
            await db.SaveChangesAsync();
        }

        public IQueryable<AP_Alvarez_Ricardo_Curso> obtenerCurso(int id)
        {
            var query = db.AP_Alvarez_Ricardo_Curso.Where(x => x.id == id).AsQueryable();
            return query;
        }

        public async Task<List<AP_Alvarez_Ricardo_Curso>> obtenerCursos()
        {
            var lista = await db.AP_Alvarez_Ricardo_Curso.Where(x => x.estado == true).ToListAsync();

            return lista;
        }

        public async Task<int> registrarCurso(AP_Alvarez_Ricardo_Curso model)
        {
            db.AP_Alvarez_Ricardo_Curso.Add(model);
            await db.SaveChangesAsync();

            return model.id;
        }
    }
}