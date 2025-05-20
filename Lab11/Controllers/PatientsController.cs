using Lab11.Exceptions;
using Lab11.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab11.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IDbService _dbService;
    public PatientsController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        try
        {
            var patientDetails = await _dbService.GetPatientDetailsAsync(id);
            return Ok(patientDetails);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}