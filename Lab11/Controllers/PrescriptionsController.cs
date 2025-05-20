using Lab11.Services;
using Microsoft.AspNetCore.Mvc;
using Lab11.DTOs;
using Lab11.Exceptions;

namespace Lab11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public PrescriptionsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrescription([FromBody] CreatePrescriptionDto request)
        {
            try
            {
                await _dbService.CreatePrescriptionAsync(request);
                return Created();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
