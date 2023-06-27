using ProjectDoctor.Models.Entities;
using System.Collections.Generic;

namespace ProjectDoctor.Models.Dtos
{
    public class ProfissionalDetalhesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int TotalConsultas { get; set; }
        public string[] Especialidades { get; set; }
    }
}