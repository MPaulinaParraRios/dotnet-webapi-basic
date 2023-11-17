using AutoMapper;
using MyVaccine.WebApi.Dtos.Vaccine;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles;

public class VaccineMapper : Profile
{
    public VaccineMapper()
    {
        CreateMap<Vaccine, VaccineRequestDto>().ReverseMap();
        CreateMap<Vaccine, VaccineResponseDto>()
            .ForMember(dest => dest.VaccineId, opt => opt.MapFrom(src => src.VaccineId)).ReverseMap();
    }

}
