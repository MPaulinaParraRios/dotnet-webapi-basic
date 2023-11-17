using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.Vaccine;
using MyVaccine.WebApi.Services.Contracts;
using MyVaccine.WebApi.Services.Implementations;

namespace MyVaccine.WebApi.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class VaccineController : ControllerBase
{
    private readonly IVaccineService _vaccineService;
    private readonly IValidator<VaccineRequestDto> _validator;
    public VaccineController(IVaccineService vaccineService, IValidator<VaccineRequestDto> validator)
    {
        _vaccineService = vaccineService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vacines = await _vaccineService.GetAll();
        return Ok(vacines);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var vacines = await _vaccineService.GetById(id);
        return Ok(vacines);
    }

    [HttpPost]
    public async Task<IActionResult> Create(VaccineRequestDto vaccinesDto)
    {
        var validationResult = await _validator.ValidateAsync(vaccinesDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var vaccines = await _vaccineService.Add(vaccinesDto);
        return Ok(vaccines);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, VaccineRequestDto vaccinesDto)
    {
        var vaccines = await _vaccineService.Update(vaccinesDto, id);
        if (vaccines == null)
        {
            return NotFound();
        }
        return Ok(vaccines);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var vaccines = await _vaccineService.Delete(id);
        if (vaccines == null)
        {
            return NotFound();
        }

        return Ok(vaccines);
    }
}
