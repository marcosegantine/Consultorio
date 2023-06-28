using Microsoft.AspNetCore.Mvc;
using ProjectDoctor.Models.Entities;
using ProjectDoctor.Repository.Interfaces;
using System.Threading.Tasks;

namespace ProjectDoctor.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class EspecialidadeController : ControllerBase
    {
        public EspecialidadeController(IEspecialidadeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Especialidade especialidade)
        {
            return await Ok(especialidade);
        }

    }
}
