using ProjectDoctor.Models.Dtos;
using ProjectDoctor.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectDoctor.Repository.Interfaces
{
    public interface IPacienteRepository : IBaseRepository
    {
        Task<IEnumerable<PacienteDto>> GetPacienteAsync();
        Task<Paciente> GetPacientesByIdAsync(int id);
    }
}
