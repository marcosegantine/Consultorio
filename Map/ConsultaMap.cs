using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDoctor.Models.Entities;

namespace ProjectDoctor.Map
{
    public class ConsultaMap : BaseMap<Consulta>
    {
        public ConsultaMap() : base("tb_consulta")
        { }
        public override void Configure(EntityTypeBuilder<Consulta> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Status).HasColumnName("status");
            builder.Property(x => x.Preco).HasPrecision(7, 2).HasColumnName("preco");
            builder.Property(x => x.DataHorario).HasColumnName("data_horario").IsRequired();

            builder.Property(x => x.PacienteId).HasColumnName("id_paciente").IsRequired();
            builder.HasOne(x => x.Paciente).WithMany(x => x.Consultas).HasForeignKey(x => x.PacienteId);
            //fazer a relação 1 pra muitos, um paciente tem relação com muitas consultas, chave estrangeira especifica para qual pacienteID ira as consultas

            builder.Property(x => x.ProfissionalId).HasColumnName("id_profissional").IsRequired();
            builder.HasOne(x => x.Profissional).WithMany(x => x.Consultas).HasForeignKey(x => x.ProfissionalId);

            builder.Property(x => x.EspecialidadeId).HasColumnName("id_especialidade").IsRequired();
            builder.HasOne(x => x.Especialidade).WithMany(x => x.Consultas).HasForeignKey(x => x.EspecialidadeId);
        }
    }
}
