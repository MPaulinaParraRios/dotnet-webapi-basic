using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations;

public class FamilyGroupService : IFamilyGroupService
{
    private readonly IBaseRepository<FamilyGroup> _familyGroupRepository;
    private readonly IMapper _mapper;
    public FamilyGroupService(IBaseRepository<FamilyGroup> familyGroupRepository, IMapper mapper)
    {
        _familyGroupRepository = familyGroupRepository;
        _mapper = mapper;
    }
    public async Task<FamilyGroupResponseDto> Add(FamilyGroupRequestDto request)
    {
        //var familyGroups = await _familyGroupRepository.FindBy(x => x.FamilyGroupId == id).FirstOrDefaultAsync();
        var familyGroups = new FamilyGroup();
        familyGroups.Name = request.Name;

        await _familyGroupRepository.Add(familyGroups);
        var response = _mapper.Map<FamilyGroupResponseDto>(familyGroups);
        return response;
    }

    public async Task<FamilyGroupResponseDto> Delete(int id)
    {
        var familyGroups = await _familyGroupRepository.FindBy(x => x.FamilyGroupId == id).FirstOrDefaultAsync();

        await _familyGroupRepository.Delete(familyGroups);
        var response = _mapper.Map<FamilyGroupResponseDto>(familyGroups);
        return response;
    }

    public async Task<IEnumerable<FamilyGroupResponseDto>> GetAll()
    {
        var familyGroups = await _familyGroupRepository.GetAll().AsNoTracking().ToListAsync();
        var response = _mapper.Map<IEnumerable<FamilyGroupResponseDto>>(familyGroups);
        return response;
    }

    public async Task<FamilyGroupResponseDto> GetById(int id)
    {
        var familyGroups = await _familyGroupRepository.FindByAsNoTracking(x => x.FamilyGroupId == id).FirstOrDefaultAsync();
        var response = _mapper.Map<FamilyGroupResponseDto>(familyGroups);
        return response;
    }

    public async Task<FamilyGroupResponseDto> Update(FamilyGroupRequestDto request, int id)
    {
        var familyGroups = await _familyGroupRepository.FindBy(x => x.FamilyGroupId == id).FirstOrDefaultAsync();
        familyGroups.Name = request.Name;

        await _familyGroupRepository.Update(familyGroups);
        var response = _mapper.Map<FamilyGroupResponseDto>(familyGroups);
        return response;
    }
}
