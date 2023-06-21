using Microsoft.EntityFrameworkCore;
using ProjectDoctor.Models.Entities;

namespace ProjectDoctor.Context
{
    public class ProjectDoctorContext : DbContext
    {
        public ProjectDoctorContext(DbContextOptions<ProjectDoctorContext> options) : base(options)
        { }

        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Profissional> Profissionals { get; set; }
        //public DbSet<ProfissionalEspecialidade> ProfissionalEspecialidade { get; set; }

        //difinindo os requisitos de cada campo da entidade agendamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        }

    }
}
