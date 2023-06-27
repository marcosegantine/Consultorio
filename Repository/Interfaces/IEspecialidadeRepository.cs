using ProjectDoctor.Models.Dtos;
using ProjectDoctor.Models.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectDoctor.Repository.Interfaces
{
    public interface IEspecialidadeRepository : IBaseRepository
    {
        Task<IEnumerable<EspecialidadeDto>> GetEspecialidades();
        Task<Especialidade> GetEspecialidadeById(int id);
    }
}