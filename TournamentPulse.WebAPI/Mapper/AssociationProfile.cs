using AutoMapper;
using TournamentPulse.WebAPI.DTOs.Academy;
using TournamentPulse.WebAPI.DTOs.Association;

namespace TournamentPulse.WebAPI.Mapper
{
    public class AssociationProfile : Profile
    {
        public AssociationProfile()
        {
            CreateMap<CreateAssociationDTO, Core.Entities.Association>();
            CreateMap<Core.Entities.Association, ReadAssociationDTO>();
        }
    }
}
