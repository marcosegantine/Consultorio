using ProjectDoctor.Models.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectDoctor.Repository.Interfaces
{
    public interface IConsultaRepository : IBaseRepository
    {
        Task<IEnumerable<Consulta>> GetConsultas();
        Task<Consulta> GetConsultaById(int Id);

    }
}
