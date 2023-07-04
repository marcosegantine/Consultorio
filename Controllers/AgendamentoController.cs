using Microsoft.AspNetCore.Mvc;
using ProjectDoctor.Repository.Interfaces;
using System.Threading.Tasks;

namespace ProjectDoctor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IConsultaRepository _repository;

        public AgendamentoController(IConsultaRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public string Get()
        {
            return "ola";
        }
    }
}
