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
    public class EspecialidadeRepository : BaseRepository, IEspecialidadeRepository
    {
        private readonly ProjectDoctorContext _context;

        public EspecialidadeRepository(ProjectDoctorContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EspecialidadeDto>> GetEspecialidades()
        {
            return await _context.Especialidades
                .Select(x => new EspecialidadeDto {Id = x.Id, Nome = x.Nome, Ativa = x.Ativa})
                .ToListAsync();
        }

        public async Task<Especialidade> GetEspecialidadeById(int id)
        {
            return await _context.Especialidades
                .Include(x => x.Profissionais)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

    }
}
