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
    public class ProfissionalRepository : BaseRepository, IProfissionalRepository
    {
        private readonly ProjectDoctorContext _context;

        public ProfissionalRepository(ProjectDoctorContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProfissionalDto>> GetProfissionais()
        {
            return await _context.Profissionals
                .Select(x => new ProfissionalDto {Id = x.Id, Nome = x.Nome, Ativo = x.Ativo}).ToListAsync();
        }

        public async Task<Profissional> GetProfissionalById(int id)
        {
            return await _context.Profissionals
                .Include(x => x.Consultas)
                .Include(x => x.Especialidades)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
