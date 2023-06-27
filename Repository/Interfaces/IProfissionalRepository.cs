using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectDoctor.Models.Dtos;
using ProjectDoctor.Models.Entities;

namespace ProjectDoctor.Repository.Interfaces
{
    public interface IProfissionalRepository : IBaseRepository
    {
        Task<IEnumerable<ProfissionalDto>> GetProfissionais();
        Task<Profissional> GetProfissionalById(int id);
    }
}
