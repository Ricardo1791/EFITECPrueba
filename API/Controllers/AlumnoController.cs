using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Alumno;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using data.Context;
using Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class AlumnoController: BaseApiController
    {
        private readonly IAlumnoRepository repo;
        private readonly IMapper mapper;

        public AlumnoController(IAlumnoRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AlumnoDTO>>> obtenerAlumnos()
        {
            var lista = await repo.obtenerAlumnos();

            var mapeo = mapper.Map<List<AlumnoDTO>>(lista);

            return Ok(mapeo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlumnoDTO>> obtenerAlumno(int id)
        {
            var alumno = await repo.obtenerAlumno(id)
                    .ProjectTo<AlumnoDTO>(mapper.ConfigurationProvider).SingleOrDefaultAsync();

            if (alumno == null){
                return BadRequest("Alumno no encontrado");
            }

            return Ok(alumno);        
        }

        [HttpPost]
        public async Task<ActionResult> registrarAlumno(AlumnoCreacionDTO model)
        {
            var mapeo = mapper.Map<AP_Alvarez_Ricardo_Alumno>(model);

            var id = await repo.registrarAlumno(mapeo);

            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> actualizarAlumno(AlumnoDTO model)
        {
            var mapeo = mapper.Map<AP_Alvarez_Ricardo_Alumno>(model);

            await repo.actualizarAlumno(mapeo);

            return NoContent();
        }

        [HttpPut("anular/{id}")]
        public async Task<ActionResult> anularAlumno(int id)
        {
            await repo.anularAlumno(id);

            return NoContent();
        }
    }
}