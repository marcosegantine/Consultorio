using Microsoft.AspNetCore.Mvc;
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

        public EspecialidadeController(IEspecialidadeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var especialidades = await _repository.GetEspecialidades();

            return especialidades.Any()
                ? Ok(especialidades)
                : NotFound("Nenhuma especialidade encontrada");
        }

    }
}
