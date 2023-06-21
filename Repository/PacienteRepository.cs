using Microsoft.EntityFrameworkCore;
using ProjectDoctor.Context;
using ProjectDoctor.Models.Dtos;
using ProjectDoctor.Models.Entities;
using ProjectDoctor.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace ProjectDoctor.Repository
{
    public class PacienteRepository : BaseRepository, IPacienteRepository
    {
        private readonly ProjectDoctorContext _context;

        public PacienteRepository(ProjectDoctorContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PacienteDto>> GetPacienteAsync()
        {
            return await _context.Pacientes
                .Select(x => new PacienteDto { Id = x.Id, Nome = x.Nome }) //reduz os dados que serão requisitados da API
                .ToListAsync();
        }

        public async Task<Paciente> GetPacientesByIdAsync(int id)
        {
            return await _context.Pacientes
                .Include(x => x.Consultas)
                .ThenInclude(c => c.Profissional)
                .ThenInclude(c => c.Especialidades)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
