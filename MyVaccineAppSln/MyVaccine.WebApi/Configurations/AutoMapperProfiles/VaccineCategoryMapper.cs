using AutoMapper;
using MyVaccine.WebApi.Dtos.VaccineCategory;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles;

public class VaccineCategoryMapper : Profile
{
    public VaccineCategoryMapper()
    {
        CreateMap<VaccineCategory, VaccineCategoryRequestDto>().ReverseMap();
        CreateMap<VaccineCategory, VaccineCategoryResponseDto>()
            .ForMember(dest => dest.VaccineCategoryId, opt => opt.MapFrom(src => src.VaccineCategoryId)).ReverseMap();
    }
}
