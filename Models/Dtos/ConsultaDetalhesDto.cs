using ProjectDoctor.Models.Entities;
using System;

namespace ProjectDoctor.Models.Dtos
{
    public class ConsultaDetalhesDto
    {
        public int Id { get; set; }
        public DateTime DataHorario { get; set; }
        public int Status { get; set; }
        public decimal Preco { get; set; }
        public PacienteDto Paciente { get; set; }
        public EspecialidadeDto Especialidade { get; set; }
        public ProfissionalDto Profissional { get; set; }
    }
}
