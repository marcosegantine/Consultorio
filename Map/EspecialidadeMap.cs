using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDoctor.Models.Entities;
using System.Numerics;

namespace ProjectDoctor.Map
{
    public class EspecialidadeMap : BaseMap<Especialidade>
    {
        public EspecialidadeMap() : base("tb_especialidade")
        {

        }

        public override void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            builder.Property(x => x.Ativa).HasColumnName("ativa");
        }
    }
}
