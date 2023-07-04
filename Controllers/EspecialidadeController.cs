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
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository _repository;
        private readonly IMapper _mapper;

        public EspecialidadeController(IEspecialidadeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var especialidades = await _repository.GetEspecialidades();

            return especialidades.Any()
                ? Ok(especialidades)
                : NotFound("Nenhuma especialidade encontrada");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Dados inválidos");

            var especialidade = await _repository.GetEspecialidadeById(id);

            var especialidadeRetorno = _mapper.Map<EspecialidadeDetalhesDto>(especialidade);

            return especialidadeRetorno != null
                ? Ok(especialidadeRetorno)
                : NotFound("Informe uma especialidade válida");

        }

        [HttpPost]
        public async Task<IActionResult> Post(EspecialidadeAdicionarDto especialidade)
        {

            if (string.IsNullOrEmpty(especialidade.Nome)) return BadRequest("Nome inválido");

            var especialidadeAdicionar = _mapper.Map<Especialidade>(especialidade);

            _repository.Add(especialidadeAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Especialidade adicionada")
                : BadRequest("Erro ao adicionar especialidade");

        }

        [HttpPut("{id}/atualizar-status/")]
        public async Task<IActionResult> Put(int id, bool ativo)
        {
            if (id <= 0) return BadRequest("Especialidade inválida");

            var especialidade = await _repository.GetEspecialidadeById(id);

            if (especialidade == null) return BadRequest("Especialidade inexistente");

            string status = ativo ? "ativo" : "inativa";
            if (especialidade.Ativa == ativo) return Ok("A specialidade já esta " + status);

            especialidade.Ativa = ativo;

            _repository.Update(especialidade);

            return await _repository.SaveChangesAsync()
                ? Ok("Status atualizado")
                : BadRequest("Erro ao atualizar status");
        }

    }
}
