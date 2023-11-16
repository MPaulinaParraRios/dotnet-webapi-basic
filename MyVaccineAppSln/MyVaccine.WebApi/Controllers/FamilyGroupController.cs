using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Services.Contracts;
using MyVaccine.WebApi.Services.Implementations;

namespace MyVaccine.WebApi.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class FamilyGroupController : ControllerBase
{
    private readonly IFamilyGroupService _familyGroupService;
    private readonly IValidator<FamilyGroupRequestDto> _validator;
    public FamilyGroupController(IFamilyGroupService familyGroupService, IValidator<FamilyGroupRequestDto> validator)
    {
        _familyGroupService = familyGroupService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var familyGroups = await _familyGroupService.GetAll();
        return Ok(familyGroups);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var familyGroups = await _familyGroupService.GetById(id);
        return Ok(familyGroups);
    }

    [HttpPost]
    public async Task<IActionResult> Create(FamilyGroupRequestDto familyGroupsDto)
    {
        var validationResult = await _validator.ValidateAsync(familyGroupsDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var familyGroups = await _familyGroupService.Add(familyGroupsDto);
        return Ok(familyGroups);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, FamilyGroupRequestDto familyGroupsDto)
    {
        var familyGroups = await _familyGroupService.Update(familyGroupsDto, id);
        if (familyGroups == null)
        {
            return NotFound();
        }
        return Ok(familyGroups);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var familyGroups = await _familyGroupService.Delete(id);
        if (familyGroups == null)
        {
            return NotFound();
        }

        return Ok(familyGroups);
    }

}
