using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.VaccineRecord;
using MyVaccine.WebApi.Services.Contracts;
using MyVaccine.WebApi.Services.Implementations;

namespace MyVaccine.WebApi.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class VaccineRecordController : ControllerBase
{
    private readonly IVaccineRecordService _vaccineRecordService;
    private readonly IValidator<VaccineRecordRequestDto> _validator;

    public VaccineRecordController(IVaccineRecordService vaccineRecordService, IValidator<VaccineRecordRequestDto> validator)
    {
        _vaccineRecordService = vaccineRecordService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vaccineRecords = await _vaccineRecordService.GetAll();
        return Ok(vaccineRecords);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var vaccineRecords = await _vaccineRecordService.GetById(id);
        return Ok(vaccineRecords);
    }

    [HttpGet("get-vaccineRecords-by-userid/{userId}")]
    public async Task<IActionResult> GetVaccineRecordsByUserId(int userId)
    {
        var vaccineRecords = await _vaccineRecordService.GetVaccineRecordsByUserId(userId);
        return Ok(vaccineRecords);
    }

   [HttpGet("get-vaccineRecords-by-dependentid/{dependentId}")]
   public async Task<IActionResult> GetVaccineRecordsByDependentId(int DependetId)
    {
        var vaccineRecords = await _vaccineRecordService.GetVaccineRecordsByDependentId(DependetId);
       return Ok(vaccineRecords);
    }

    [HttpGet("get-vaccineRecords-by-vaccineid/{VaccineId}")]
    public async Task<IActionResult> GetVaccineRecordsByVaccineId(int VaccineId)
    {
        var vaccineRecords = await _vaccineRecordService.GetVaccineRecordsByVaccineId(VaccineId);
        return Ok(vaccineRecords);
    }

    [HttpPost]
    public async Task<IActionResult> Create(VaccineRecordRequestDto vaccineRecordsDto)
    {
        var validationResult = await _validator.ValidateAsync(vaccineRecordsDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var vaccineRecords = await _vaccineRecordService.Add(vaccineRecordsDto);
        return Ok(vaccineRecords);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, VaccineRecordRequestDto vaccineRecordsDto)
    {
        var vaccineRecords = await _vaccineRecordService.Update(vaccineRecordsDto, id);
        if (vaccineRecords == null)
        {
            return NotFound();
        }

        return Ok(vaccineRecords);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var vaccineRecords = await _vaccineRecordService.Delete(id);
        if (vaccineRecords == null)
        {
            return NotFound();
        }

        return Ok(vaccineRecords);
    }
}
