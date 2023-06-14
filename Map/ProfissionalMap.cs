using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDoctor.Models.Entities;

namespace ProjectDoctor.Map
{
    public class ProfissionalMap : BaseMap<Profissional>
    {
        public ProfissionalMap() : base("tb_profissional")
        {

        }

        public override void Configure(EntityTypeBuilder<Profissional> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo");


            //relacionamento de muitos para muitos
            builder.HasMany(x => x.Especialidades) //o profissional tem muitas especialidade
                .WithMany(x => x.Profissionais) // cada especialidade tem muitos profissionais
                .UsingEntity<ProfissionalEspecialidade>(
                    x => x.HasOne(p => p.Especialidade).WithMany().HasForeignKey(x => x.EspecialidadeId),
                    x => x.HasOne(p => p.Profissionais).WithMany().HasForeignKey(x => x.ProfissionalId),
                    x =>
                    {
                        x.ToTable("tb_profissional_especialidade"); //renomeando o nome da tabela
                        x.HasKey(p => new { p.EspecialidadeId, p.ProfissionalId }); //cria uma nova chave composta com EspecialidadeId e ProfissionalId
                        x.Property(p => p.EspecialidadeId).HasColumnName("id_especialidade").IsRequired();
                        x.Property(p => p.ProfissionalId).HasColumnName("id_profissional").IsRequired();
                    }
                ); ;
        }
    }
}
