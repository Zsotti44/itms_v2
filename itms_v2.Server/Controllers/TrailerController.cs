using itms_v2.Server.Models;
using itms_v2.Server.Models.Dtos;
using itms_v2.Server.Models.ResponseModel;
using itms_v2.Server.Services.TrailerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itms_v2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")/*,Authorize(Roles ="Admin")*/]
    public class TrailerController:ControllerBase
    {
        
        private readonly ITrailerService _trailerService;

        public TrailerController(ITrailerService trailerService)
        {
            _trailerService = trailerService;
        }
        
        [HttpPost("addtrailer")]
        public async Task<ActionResult<ServiceResponse<List<GetTrailerDto>>>> AddTrailer(AddTrailerDto trailer)
        {
            return Ok(await _trailerService.AddTrailer(trailer));
        }
       [HttpPut("edittrailer")]
        public async Task<ActionResult<ServiceResponse<List<GetTrailerDto>>>> EditTrailer(Trailer trailer)
        {
            return Ok(await _trailerService.EditTrailer(trailer));
        }
        [HttpGet("getalltrailer")]
        public async Task<ActionResult<ServiceResponse<List<Trailer>>>> GetAllTrailer()
        {
            return Ok(await _trailerService.GetAllTrailers());
        }
        [HttpGet("getTrailerSelectOptions")]
        public async Task<ActionResult<ServiceResponse<List<TrailerSelectOptionsDto>>>> GetTrailerSelectOptions()
        {
            return Ok(await _trailerService.GetTrailerSelectOptions());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Trailer>>> GetTrailerById(int id)
        {
            return Ok(await _trailerService.GetTrailerById(id));
        }
    }
}