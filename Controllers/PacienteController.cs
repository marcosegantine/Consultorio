using AutoMapper;
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

            var retornoPaciente = _mapper.Map<PacienteDetailsDto>(paciente);

            var pacienteTest = _mapper.Map<Paciente>(retornoPaciente);

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
                ? Ok("Paciente adicionado como sucesso!")
                : BadRequest("Erro ao adicionar o paciente");
        }
    }
}
