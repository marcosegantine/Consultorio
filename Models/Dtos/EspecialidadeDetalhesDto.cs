using ProjectDoctor.Models.Entities;
using System.Collections.Generic;

namespace ProjectDoctor.Models.Dtos
{
    internal class EspecialidadeDetalhesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativa { get; set; }
        public List<ProfissionalDto> Profissionais { get; set; }
    }
}