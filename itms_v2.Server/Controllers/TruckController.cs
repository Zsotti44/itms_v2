using itms_v2.Server.Models.ResponseModel;
using itms_v2.Server.Models;
using itms_v2.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using itms_v2.Server.Models.Dtos;

namespace itms_v2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")/*,Authorize(Roles ="Admin")*/]

    public class TruckController : ControllerBase
    {
        private readonly ITruckService _truckService;

        public TruckController(ITruckService truckService)
        {
            _truckService = truckService;
        }
        
        [HttpPost("addtruck")]
        public async Task<ActionResult<ServiceResponse<List<GetTruckDto>>>> AddTruck(AddTruckDto truck)
        {
            return Ok(await _truckService.AddTruck(truck));
        }
        [HttpPut("edittruck")]
        public async Task<ActionResult<ServiceResponse<List<GetTruckDto>>>> EditTruck(Truck truck)
        {
            return Ok(await _truckService.EditTruck(truck));
        }

        [HttpGet("getalltruck")]
        public async Task<ActionResult<ServiceResponse<List<GetTruckDto>>>> GetAllTrucks()
        {
            return Ok(await _truckService.GetAllTrucks());
        }
        [HttpGet("getTruckSelectOptions")]
        public async Task<ActionResult<ServiceResponse<List<TruckSelectOptionsDto>>>> GetTruckSelectOptions()
        {
            return Ok(await _truckService.GetTruckSelectOptions());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTruckDto>>> GetTruckById(int id)
        {
            return Ok(await _truckService.GetTruckById(id));
        }
       /* [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTruckDto>>> DeleteTruck(int id)
        {
            return Ok(await _truckService.DeleteTruck(id));
        }*/
    }
}