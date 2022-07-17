using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Context;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly DatabaseContext db;

        public AlumnoRepository(DatabaseContext db)
        {
            this.db = db;
        }
        
        public async Task actualizarAlumno(AP_Alvarez_Ricardo_Alumno model)
        {
            db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task anularAlumno(int id)
        {
            var model = await db.AP_Alvarez_Ricardo_Alumno.FindAsync(id);
            model.estado = false;
            await db.SaveChangesAsync();
        }   

        public IQueryable<AP_Alvarez_Ricardo_Alumno> obtenerAlumno(int id)
        {
             var query = db.AP_Alvarez_Ricardo_Alumno.Where(x => x.id == id).AsQueryable();

             return query;
        }

        public async Task<List<AP_Alvarez_Ricardo_Alumno>> obtenerAlumnos()
        {
            var lista = await db.AP_Alvarez_Ricardo_Alumno.Where(x => x.estado == true).ToListAsync();

            return lista;
        }

        public async Task<int> registrarAlumno(AP_Alvarez_Ricardo_Alumno model)
        {
            db.AP_Alvarez_Ricardo_Alumno.Add(model);
            await db.SaveChangesAsync();

            return model.id;
        }
    }
}