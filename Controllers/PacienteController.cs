﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectDoctor.Models.Dtos;
using ProjectDoctor.Models.Entities;
using ProjectDoctor.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDoctor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _repository;
        private readonly IMapper _mapper;

        public PacienteController(IPacienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var pacientes = await _repository.GetPacienteAsync();

            return pacientes.Any()
                ? Ok(pacientes)
                : BadRequest("Nenhum paciente encontrado");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var paciente = await _repository.GetPacientesByIdAsync(id);

            var retornoPaciente = _mapper.Map<PacienteDetalhesDto>(paciente);

            return retornoPaciente != null
                ? Ok(retornoPaciente)
                : BadRequest("Paciente não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(PacienteAddDto paciente)
        {
            if (paciente == null) return BadRequest("Dados inválidos");

            var pacienteAdd = _mapper.Map<Paciente>(paciente);

            _repository.Add(pacienteAdd);

            return await _repository.SaveChangesAsync()
                ? Ok("Paciente adicionado com sucesso!")
                : BadRequest("Erro ao adicionar o paciente");
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, PacienteAtualizarDto paciente)
        {
            if (id <= 0) return BadRequest("Usuarionão informado");

            var pacienteDb = await _repository.GetPacientesByIdAsync(id);

            var pacienteAtualizar = _mapper.Map(paciente, pacienteDb);

            _repository.Update(pacienteAtualizar);

            return await _repository.SaveChangesAsync()
                ? Ok("Paciente atualizado com sucesso!")
                : BadRequest("Erro ao atualizadar o paciente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Paciente não encontrado");

            var pacienteToDelete = await _repository.GetPacientesByIdAsync(id);

            if (pacienteToDelete == null) return NotFound("Paciente não econtrado");

            _repository.Delete(pacienteToDelete);

            return await _repository.SaveChangesAsync()
                ? Ok("Paciente Deletado com sucesso")
                : BadRequest("Erro ao deletar o paciente");
        }

    }
}
