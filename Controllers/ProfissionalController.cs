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
    [Route("api/controller")]

    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalRepository _repository;
        private readonly IMapper _mapper;

        public ProfissionalController(IProfissionalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var profissionais = await _repository.GetProfissionais();

            return profissionais.Any()
                ? Ok(profissionais)
                : NotFound("Nenhum profissional encontrado");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Profissional inválido");

            var profissional = await _repository.GetProfissionalById(id);

            var profissionalRetorno = _mapper.Map<ProfissionalDetalhesDto>(profissional);

            return profissionalRetorno != null
                ? Ok(profissionalRetorno)
                : NotFound("Profissional não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProfissionalAdicionarDto profissional)
        {
            if (string.IsNullOrEmpty(profissional.Nome)) return BadRequest("Dados incompletos");

            var profissionalAdicionar = _mapper.Map<Profissional>(profissional);

            _repository.Add(profissionalAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Profissional adicionado com sucesso")
                : BadRequest("Erro ao adicionar Profissional");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProfissiolAtualizarDto profissional)
        {
            if (id <= 0) return BadRequest("Informe um Profissional válido");

            var profissionalDB = await _repository.GetProfissionalById(id);

            if (profissionalDB == null)
                return NotFound("Profissional não encontrado no banco de dados");

            var profissionalAtualizar = _mapper.Map(profissional, profissionalDB);

            _repository.Update(profissionalAtualizar);

            return await _repository.SaveChangesAsync()
                ? Ok("Profissional atualizado")
                : BadRequest("Erro ao atualizar Profissional");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Informe um profissional valido");

            var profissional = await _repository.GetProfissionalById(id);

            if (profissional == null)
                return NotFound("Profissional não encontrado");

            _repository.Delete(profissional);

            return await _repository.SaveChangesAsync()
                ? Ok("Profissional deletado")
                : BadRequest("Erro ao deletar Profissional");

        }

    }
}
