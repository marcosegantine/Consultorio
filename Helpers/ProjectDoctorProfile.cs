using AutoMapper;
using ProjectDoctor.Models.Dtos;
using ProjectDoctor.Models.Entities;

namespace ProjectDoctor.Helpers
{
    public class ProjectDoctorProfile : Profile
    {

        public ProjectDoctorProfile()
        {
            CreateMap<Paciente, PacienteDetailsDto>().ReverseMap(); //faz um mapeamento reverso
            CreateMap<ConsultaDto, Consulta>()
                .ForMember(dest => dest.Profissional, opt => opt.Ignore())
                .ForMember(dest => dest.Especialidade, opt => opt.Ignore());

            CreateMap<Consulta, ConsultaDto>() //cria um mapeamento de Consulta para ConsultaDto
                .ForMember(dest => dest.Especialidade, opt => opt.MapFrom(src => src.Especialidade.Nome))
                .ForMember(dest => dest.Profissional, opt => opt.MapFrom(src => src.Profissional.Nome));

            CreateMap<PacienteAddDto, Paciente>();

            CreateMap<PacienteUpdateDto, Paciente>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); //verifica e altera apenas os valores não nullos que forem passados 
        }
    }
}
