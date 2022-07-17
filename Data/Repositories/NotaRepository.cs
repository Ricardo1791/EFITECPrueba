using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Context;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly DatabaseContext db;

        public NotaRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task actualizarNota(AP_Alvarez_Ricardo_Nota model)
        {
            db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task anularNota(int id)
        {
            var model = await db.AP_Alvarez_Ricardo_Nota.FindAsync(id);
            model.estado = false;

            await db.SaveChangesAsync();
        }

        public IQueryable<AP_Alvarez_Ricardo_Nota> obtenerNota(int id)
        {
            var query = db.AP_Alvarez_Ricardo_Nota.Where(x => x.id == id);
            return query;
        }

        public async Task<List<AP_Alvarez_Ricardo_Nota>> obtenerNotas()
        {
            var lista = await db.AP_Alvarez_Ricardo_Nota.Where(x => x.estado == true).ToListAsync();

            return lista;
        }

        public async Task<int> registrarNota(AP_Alvarez_Ricardo_Nota model)
        {
            db.AP_Alvarez_Ricardo_Nota.Add(model);
            await db.SaveChangesAsync();

            return model.id;
        }
    }
}