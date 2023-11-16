using AutoMapper;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles;

public class FamilyGroupMapper : Profile
{
    public FamilyGroupMapper()
    {
        CreateMap<FamilyGroup, FamilyGroupRequestDto>().ReverseMap();
        CreateMap<FamilyGroup, FamilyGroupResponseDto>()
            .ForMember(dest => dest.FamilyGroupId, opt => opt.MapFrom(src => src.FamilyGroupId)).ReverseMap();
    }
}
