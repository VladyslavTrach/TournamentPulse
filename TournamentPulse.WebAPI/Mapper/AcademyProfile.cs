using AutoMapper;
using TournamentPulse.WebAPI.DTOs.Academy;

namespace TournamentPulse.WebAPI.Mapper
{
    public class AcademyProfile : Profile
    {
        public AcademyProfile()
        {
            CreateMap<CreateAcademyDTO, Core.Entities.Academy>();
            CreateMap<Core.Entities.Academy, ReadAcademyDTO>();
        }
    }
}
