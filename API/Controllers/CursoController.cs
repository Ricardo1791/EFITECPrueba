using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Curso;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using data.Context;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class CursoController: BaseApiController
    {
        private readonly ICursoRepository _repo;
        private readonly IMapper _mapper;
        public CursoController(ICursoRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<CursoDTO>>> obtenerCursos()
        {
            var lista = await _repo.obtenerCursos();

            var mapeo = _mapper.Map<List<CursoDTO>>(lista);

            return Ok(mapeo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CursoDTO>> obtenerCurso(int id)
        {
            var model = await _repo.obtenerCurso(id)
                            .ProjectTo<CursoDTO>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();

            if (model == null){
                return BadRequest("Curso no encontrado");
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> registrarCurso(CursoCreacionDTO model)
        {
            var mapeo = _mapper.Map<AP_Alvarez_Ricardo_Curso>(model);

            var id = await _repo.registrarCurso(mapeo);

            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> actualizarCurso(CursoDTO model)
        {
            var mapeo = _mapper.Map<AP_Alvarez_Ricardo_Curso>(model);

            await _repo.actualizarCurso(mapeo);

            return NoContent();
        }

        [HttpPut("anular/{id}")]
        public async Task<ActionResult> anularCurso(int id)
        {
            await _repo.anularCurso(id);

            return NoContent();
        }
    }
}