using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.VaccineCategory;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class VaccineCategoryController : ControllerBase
{
    private readonly IVaccineCategoryService _vaccineCategoryService;
    private readonly IValidator<VaccineCategoryRequestDto> _validator;
    public VaccineCategoryController(IVaccineCategoryService vaccineCategoryService, IValidator<VaccineCategoryRequestDto> validator)
    {
        _vaccineCategoryService = vaccineCategoryService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vaccinecategories = await _vaccineCategoryService.GetAll();
        return Ok(vaccinecategories);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var vaccinecategories = await _vaccineCategoryService.GetById(id);
        return Ok(vaccinecategories);
    }

    [HttpPost]
    public async Task<IActionResult> Create(VaccineCategoryRequestDto vaccinecategoriesDto)
    {
        var validationResult = await _validator.ValidateAsync(vaccinecategoriesDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var vaccinecategories = await _vaccineCategoryService.Add(vaccinecategoriesDto);
        return Ok(vaccinecategories);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, VaccineCategoryRequestDto vaccinecategoriesDto)
    {
        var vaccinecategories = await _vaccineCategoryService.Update(vaccinecategoriesDto, id);
        if (vaccinecategories == null)
        {
            return NotFound();
        }
        return Ok(vaccinecategories);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var vaccinecategories = await _vaccineCategoryService.Delete(id);
        if (vaccinecategories == null)
        {
            return NotFound();
        }

        return Ok(vaccinecategories);
    }
}
