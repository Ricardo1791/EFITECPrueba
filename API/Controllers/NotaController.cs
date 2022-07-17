using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Nota;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using data.Context;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class NotaController: BaseApiController
    {
        private readonly INotaRepository _repo;
        private readonly IMapper _mapper;
        public NotaController(INotaRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;            
        }

        [HttpGet]
        public async Task<ActionResult> obtenerNotas()
        {
            var lista = await _repo.obtenerNotas();

            if (string.IsNullOrEmpty(lista)){
                lista = "[]";
            }

            return Content(lista, "application/json");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotaDTO>> obtenerNota(int id)
        {
            var model = await _repo.obtenerNota(id).ProjectTo<NotaDTO>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();

            if (model == null){
                return BadRequest("Registro no encontrado");
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> registrarNota(NotaCreacionDTO model)
        {
            var mapeo = _mapper.Map<AP_Alvarez_Ricardo_Nota>(model);

            var id = await _repo.registrarNota(mapeo);

            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> actualizarNota(NotaDTO model)
        {
            var mapeo = _mapper.Map<AP_Alvarez_Ricardo_Nota>(model);

            await _repo.actualizarNota(mapeo);

            return NoContent();
        }

        [HttpPut("anular/{id}")]
        public async Task<ActionResult> anularNota(int id)
        {
            await _repo.anularNota(id);

            return NoContent();
        }

        [HttpGet("comboalumno")]
        public async Task<ActionResult> comboalumno()
        {
            var lista = await _repo.comboAlumnos();

            if (string.IsNullOrEmpty(lista)){
                lista = "[]";
            }

            return Content(lista, "application/json");
        }

        [HttpGet("combocurso")]
        public async Task<ActionResult> combocurso()
        {
            var lista = await _repo.comboCursos();

            if (string.IsNullOrEmpty(lista)){
                lista = "[]";
            }

            return Content(lista, "application/json");
        }
    }
}