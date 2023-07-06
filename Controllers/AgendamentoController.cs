using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectDoctor.Models.Dtos;
using ProjectDoctor.Models.Entities;
using ProjectDoctor.Models.Params;
using ProjectDoctor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDoctor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IConsultaRepository _repository;
        private readonly IMapper _mapper;

        public AgendamentoController(IConsultaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]ConsultaParams parametros)
        {
            var consultas = await _repository.GetConsultas(parametros);
           
            var consultasRetorno = _mapper.Map<IEnumerable<ConsultaDto>>(consultas);
           
            return consultasRetorno.Any()
                ? Ok(consultasRetorno)
                : NotFound("Nenhuma consulta encontrada.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Consulta inválida.");

            var consulta = await _repository.GetConsultaById(id);

            var consultaRetorno = _mapper.Map<ConsultaDetalhesDto>(consulta);

            return consultaRetorno != null
                ? Ok(consultaRetorno) : NotFound("Consulta não encontrada.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(ConsultaAdicionarDto consulta)
        {
            if (consulta == null) return BadRequest("Dados inválidos.");

            var consultaAdicionar = _mapper.Map<Consulta>(consulta);

            _repository.Add(consultaAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Consulta adicionada com sucesso")
                : BadRequest("Erro ao adicionar consulta");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ConsultaAtualizarDto consulta)
        {
            if (consulta == null) return BadRequest("Dados inválidos");

            var consultaDb = await _repository.GetConsultaById(id);

            if (consultaDb == null) return NotFound("Consulta não consta na base de Dados");
            if (consulta.DataHorario == new DateTime()) consulta.DataHorario = consultaDb.DataHorario;
            if (consulta.ProfissionalId <= 0) consulta.ProfissionalId = consultaDb.ProfissionalId;
            if (consulta.EspecialidadeId <= 0) consulta.EspecialidadeId = consultaDb.EspecialidadeId;

            var consultaAtualizar = _mapper.Map(consulta, consultaDb);
            _repository.Update(consultaAtualizar);

            return await _repository.SaveChangesAsync()
                ? Ok("Consulta atualizada com sucesso")
                : BadRequest("Erro ao atualizar consulta");

        }

    }
}
