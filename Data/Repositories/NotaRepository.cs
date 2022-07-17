using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Context;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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

        public async Task<string> comboAlumnos()
        {
            var query = await (from i in db.AP_Alvarez_Ricardo_Alumno
                               where i.estado == true
                               select new 
                               {
                                 text = i.nombres + " " + i.apellidos,
                                 value = i.id
                               }).ToListAsync();

            return JsonSerializer.Serialize(query);
        }

        public async Task<string> comboCursos()
        {
            var query = await (from i in db.AP_Alvarez_Ricardo_Curso
                                where i.estado == true
                                select new 
                                {
                                    text = i.nombre,
                                    value = i.id
                                }).ToListAsync();

            return JsonSerializer.Serialize(query);
        }

        public IQueryable<AP_Alvarez_Ricardo_Nota> obtenerNota(int id)
        {
            var query = db.AP_Alvarez_Ricardo_Nota.Where(x => x.id == id);
            return query;
        }

        public async Task<string> obtenerNotas()
        {
            var query = await (from i in db.AP_Alvarez_Ricardo_Nota
                               join j in db.AP_Alvarez_Ricardo_Alumno on i.idalumno equals j.id
                               join k in db.AP_Alvarez_Ricardo_Curso on i.idcurso equals k.id
                               where i.estado == true
                               select new
                               {
                                  id = i.id,
                                  idcurso = i.idcurso,
                                  idalumno = i.idalumno,
                                  curso = k.nombre,
                                  alumno = j.nombres + " " + j.apellidos,
                                  practica1 = i.practica1,
                                  practica2 = i.practica2,
                                  practica3 = i.practica3,
                                  parcial = i.parcial,
                                  final = i.final,
                                  estado = i.estado
                               }).ToListAsync();

            return JsonSerializer.Serialize(query);
        }

        public async Task<int> registrarNota(AP_Alvarez_Ricardo_Nota model)
        {
            db.AP_Alvarez_Ricardo_Nota.Add(model);
            await db.SaveChangesAsync();

            return model.id;
        }
    }
}