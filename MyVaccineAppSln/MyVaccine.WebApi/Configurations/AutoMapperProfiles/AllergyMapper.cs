﻿using AutoMapper;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles;

public class AllergyMapper : Profile
{
    public AllergyMapper()
    {
        CreateMap<Allergy, AllergyRequestDto>().ReverseMap();
        CreateMap<Allergy, AllergyResponseDto>()
            .ForMember(dest => dest.AllergyId, opt => opt.MapFrom(src => src.AllergyId)).ReverseMap();
    }
}
