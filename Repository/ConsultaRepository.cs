using Microsoft.EntityFrameworkCore;
using ProjectDoctor.Context;
using ProjectDoctor.Models.Entities;
using ProjectDoctor.Models.Params;
using ProjectDoctor.Repository.Interfaces;
using System;
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
        public async Task<IEnumerable<Consulta>> GetConsultas(ConsultaParams parametro)
        {
            var consultas = _context.Consultas
                .Include(x => x.Paciente)
                .Include(x => x.Profissional)
                .Include(x => x.Especialidade).AsQueryable();


            DateTime dataVazia = new();

            if (parametro.Datainicio != dataVazia)
                consultas = consultas.Where(x => x.DataHorario >= parametro.Datainicio);

            if (parametro.DataFim != dataVazia)
                consultas = consultas.Where(x => x.DataHorario <= parametro.DataFim);

            if (!string.IsNullOrEmpty(parametro.NomeEspecialidade))
            {
                string nomeEspecialidade = parametro.NomeEspecialidade.ToLower().Trim(); //metodo trim remove todos espaços em branco no inicio/fim da string
                consultas = consultas.Where(x => x.Especialidade.Nome.ToLower().Contains(nomeEspecialidade));
            }

            return await consultas.ToListAsync();

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
