using Microsoft.EntityFrameworkCore;
using ProjectDoctor.Context;
using ProjectDoctor.Models.Entities;
using ProjectDoctor.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDoctor.Repository
{
    public class ConsultaRepository : BaseRepository, IConsultaRepository
    {
        public readonly ProjectDoctorContext _context;
        public ConsultaRepository(ProjectDoctorContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Consulta>> GetConsultas()
        {
            return await _context.Consultas
                .Include(x => x.Paciente)
                .Include(x => x.Profissional)
                .Include(x => x.Especialidade)
                .ToListAsync();
        }

        public async Task<Consulta> GetConsultaById(int id)
        {
            return await _context.Consultas
                .Include(x => x.Paciente)
                .Include(x => x.Profissional)
                .Include(x => x.Especialidade)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

        }

    }
}
