using AutoMapper;
using MyVaccine.WebApi.Dtos.VaccineRecord;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles;

public class VaccineRecordMapper : Profile
{
    public VaccineRecordMapper()
    {
        CreateMap<VaccineRecord, VaccineRecordRequestDto>().ReverseMap();
        CreateMap<VaccineRecord, VaccineRecordResponseDto>()
            .ForMember(dest => dest.VaccineRecordId, opt => opt.MapFrom(src => src.VaccineRecordId)).ReverseMap();
    }
}
