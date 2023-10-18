using AutoMapper;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.CategoryFighter;

public class CategoryFighterProfile : Profile
{
    public CategoryFighterProfile()
    {
        CreateMap<TournamentCategoryFighter, CategoryFighterListViewModel>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Fighters, opt => opt.MapFrom(src => src.Fighter.FullName));
    }
}
