using AutoMapper;
using ProjectDoctor.Controllers;
using ProjectDoctor.Models.Dtos;
using ProjectDoctor.Models.Entities;
using System.Linq;

namespace ProjectDoctor.Helpers
{
    public class ProjectDoctorProfile : Profile
    {

        public ProjectDoctorProfile()
        {
            CreateMap<ConsultaDto, Consulta>()
                .ForMember(dest => dest.Profissional, opt => opt.Ignore())
                .ForMember(dest => dest.Especialidade, opt => opt.Ignore());

            CreateMap<Consulta, ConsultaDto>() //cria um mapeamento de Consulta para ConsultaDto
                .ForMember(dest => dest.Especialidade, opt => opt.MapFrom(src => src.Especialidade.Nome))
                .ForMember(dest => dest.Profissional, opt => opt.MapFrom(src => src.Profissional.Nome));

            CreateMap<Paciente, PacienteDetailsDto>().ReverseMap(); //faz um mapeamento reverso
            
            CreateMap<PacienteAddDto, Paciente>();

            CreateMap<PacienteAtualizarDto, Paciente>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); //verifica e altera apenas os valores não nullos que forem passados 

            CreateMap<Profissional, ProfissionalDto>();

            CreateMap<Profissional, ProfissionalDetalhesDto>()
                .ForMember(dest => dest.TotalConsultas, opt => opt.MapFrom(src => src.Consultas.Count()))
                .ForMember(dest => dest.Especialidades, opt => opt.MapFrom(src => src.Especialidades.Select(x => x.Nome).ToArray()));

            CreateMap<ProfissionalAdicionarDto, Profissional>();

            CreateMap<ProfissiolAtualizarDto, Profissional>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<EspecialidadeAdicionarDto, Especialidade>();

            CreateMap<EspecialidadeAtualizarDto, Especialidade>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
