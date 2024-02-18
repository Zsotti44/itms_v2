using itms_v2.Server.Models;
using itms_v2.Server.Models.Dtos;
using itms_v2.Server.Models.ResponseModel;
using itms_v2.Server.Services.ShiftServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itms_v2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")/*,Authorize(Roles ="Admin")*/]
    public class ShiftController:ControllerBase
    {
        
        private readonly IShiftService _ShiftService;

        public ShiftController(IShiftService ShiftService)
        {
            _ShiftService = ShiftService;
        }
        
        [HttpPost("addShift")]
        public async Task<ActionResult<ServiceResponse<List<GetShiftDto>>>> AddShift(AddShiftDto Shift)
        {
            return Ok(await _ShiftService.AddShift(Shift));
        }

        [HttpGet("getallShift")]
        public async Task<ActionResult<ServiceResponse<List<Shift>>>> GetAllShift()
        {
            return Ok(await _ShiftService.GetAllShifts());
        }
        [HttpPut("updateWorkTruck")]
        public async Task<ActionResult<ServiceResponse<List<Shift>>>> UpdateWorkTruck(UpdateWorkTruckDto WT)
        {
            return Ok(await _ShiftService.UpdateWorkTruckById(WT));
        }
        [HttpPut("addWorkTruck")]
        public async Task<ActionResult<ServiceResponse<List<Shift>>>> AddWorkTruck(AddWorkerDto WT)
        {
            return Ok(await _ShiftService.AddWorkTruck(WT));
        }
        [HttpGet("getDispatcherSelectOptions")]
        public async Task<ActionResult<ServiceResponse<List<Dispatcher>>>> getDispatcherSelectOptions()
        {
            return Ok(await _ShiftService.getDispatcherSelectOptions());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Shift>>> GetShiftById(int id)
        {
            return Ok(await _ShiftService.GetShiftById(id));
        }
    }
}