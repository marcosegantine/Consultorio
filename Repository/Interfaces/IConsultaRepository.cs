using ProjectDoctor.Models.Entities;
using ProjectDoctor.Models.Params;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectDoctor.Repository.Interfaces
{
    public interface IConsultaRepository : IBaseRepository
    {
        Task<IEnumerable<Consulta>> GetConsultas(ConsultaParams parametro);
        Task<Consulta> GetConsultaById(int Id);

    }
}
