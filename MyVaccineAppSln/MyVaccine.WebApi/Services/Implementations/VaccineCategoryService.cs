using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Dtos.Vaccine;
using MyVaccine.WebApi.Dtos.VaccineCategory;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations;

public class VaccineCategoryService : IVaccineCategoryService
{
    private readonly IBaseRepository<VaccineCategory> _vaccineCategoryRepository;
    private readonly IMapper _mapper;
    public VaccineCategoryService(IBaseRepository<VaccineCategory> vaccineCategoryRepository, IMapper mapper)
    {
        _vaccineCategoryRepository = vaccineCategoryRepository;
        _mapper = mapper;
    }
    public async Task<VaccineCategoryResponseDto> Add(VaccineCategoryRequestDto request)
    {
        // var VaccineCategories = await _vaccineCategoryRepository.FindBy(x => x.VaccineCategoryId == id).FirstOrDefaultAsync();
        var VaccineCategories = new VaccineCategory();
        VaccineCategories.Name = request.Name;

        await _vaccineCategoryRepository.Add(VaccineCategories);
        var response = _mapper.Map<VaccineCategoryResponseDto>(VaccineCategories);
        return response;
    }

    public async Task<VaccineCategoryResponseDto> Delete(int id)
    {
        var VaccineCategories = await _vaccineCategoryRepository.FindBy(x => x.VaccineCategoryId == id).FirstOrDefaultAsync();

        await _vaccineCategoryRepository.Delete(VaccineCategories);
        var response = _mapper.Map<VaccineCategoryResponseDto>(VaccineCategories);
        return response;
    }

    public async Task<IEnumerable<VaccineCategoryResponseDto>> GetAll()
    {
        var VaccineCategories = await _vaccineCategoryRepository.GetAll().AsNoTracking().ToListAsync();
        var response = _mapper.Map<IEnumerable<VaccineCategoryResponseDto>>(VaccineCategories);
        return response;
    }

    public async Task<VaccineCategoryResponseDto> GetById(int id)
    {
        var VaccineCategories = await _vaccineCategoryRepository.FindByAsNoTracking(x => x.VaccineCategoryId == id).FirstOrDefaultAsync();
        var response = _mapper.Map<VaccineCategoryResponseDto>(VaccineCategories);
        return response;
    }

    public async Task<VaccineCategoryResponseDto> Update(VaccineCategoryRequestDto request, int id)
    {
        var VaccineCategories = await _vaccineCategoryRepository.FindBy(x => x.VaccineCategoryId == id).FirstOrDefaultAsync();
        VaccineCategories.Name = request.Name;

        await _vaccineCategoryRepository.Update(VaccineCategories);
        var response = _mapper.Map<VaccineCategoryResponseDto>(VaccineCategories);
        return response;
    }
}
