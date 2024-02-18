using itms_v2.Server.Models;
using itms_v2.Server.Models.Dtos;
using itms_v2.Server.Models.ResponseModel;
using itms_v2.Server.Services.TruckDriverServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itms_v2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")/*,Authorize(Roles ="Admin")*/]
    public class TruckDriverController:ControllerBase
    {
        private readonly ITruckDriverService _truckDriverService;
        public TruckDriverController(ITruckDriverService truckDriverService)
        {
            _truckDriverService = truckDriverService;
        }

        [HttpPost("addtruckdriver")]
        public async Task<ActionResult<ServiceResponse<List<GetTruckDriverDto>>>> AddTruckDriver(AddTruckDriverDto driver)
        {
            return Ok(await _truckDriverService.AddTruckDriver(driver));
        }
        [HttpPut("edittruckdriver")]
        public async Task<ActionResult<ServiceResponse<List<GetTruckDriverDto>>>> EditTruckDriver(TruckDriver driver)
        {
            return Ok(await _truckDriverService.EditTruckDriver(driver));
        }

        [HttpGet("getalltruckdriver")]
        public async Task<ActionResult<ServiceResponse<List<GetTruckDriverDto>>>> GetAllTruckDrivers()
        {
            return Ok(await _truckDriverService.GetAllTruckDrivers());
        }
        [HttpGet("getTruckDriverSelectOptions")]
        public async Task<ActionResult<ServiceResponse<List<TruckDriverSelectOptionsDto>>>> GetTruckDriverSelectOptions()
        {
            return Ok(await _truckDriverService.GetTruckDriverSelectOptions());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTruckDriverDto>>> GetTruckDriverById(int id)
        {
            return Ok(await _truckDriverService.GetTruckDriverById(id));
        }
    }
}