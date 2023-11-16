using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.Dependent;
using MyVaccine.WebApi.Services.Contracts;
using MyVaccine.WebApi.Services.Implementations;


namespace MyVaccine.WebApi.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AllergyController : ControllerBase
{
    private readonly IAllergyService _allergyService;
    private readonly IValidator<AllergyRequestDto> _validator;
    public AllergyController(IAllergyService allergyService, IValidator<AllergyRequestDto> validator)
    {
        _allergyService = allergyService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allergys = await _allergyService.GetAll();
        return Ok(allergys);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var allergys = await _allergyService.GetById(id);
        return Ok(allergys);
    }

    [HttpGet("get-allergies-by-userid/{userId}")]
    public async Task<IActionResult> GetAllergysByUserId(int userId)
    {
        var allergys = await _allergyService.GetAllergysByUserId(userId);
        return Ok(allergys);
    }

    [HttpPost]
    public async Task<IActionResult> Create (AllergyRequestDto allergysDto)
    {
        var validationResult = await _validator.ValidateAsync(allergysDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var allergys = await _allergyService.Add(allergysDto);
        return Ok(allergys);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, AllergyRequestDto allergysDto)
    {
        var allergys = await _allergyService.Update(allergysDto, id);
        if (allergys == null)
        {
            return NotFound();
        }
        return Ok(allergys);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var allergys = await _allergyService.Delete(id);
        if (allergys == null)
        {
            return NotFound();
        }

        return Ok(allergys);
    }
}
