using itms_v2.Server.Models;
using itms_v2.Server.Models.Dtos;
using itms_v2.Server.Models.ResponseModel;

namespace itms_v2.Server.Services.ShiftServices
{
    public interface IShiftService
    {
    Task<ServiceResponse<List<GetShiftDto>>> GetAllShifts();
    Task<ServiceResponse<List<GetShiftDto>>> AddShift(AddShiftDto newShift);
    Task<ServiceResponse<GetShiftFullDto>> GetShiftById(int id);
    Task<ServiceResponse<GetShiftFullDto>> UpdateWorkTruckById(UpdateWorkTruckDto updateWorkTruck);
    Task<ServiceResponse<GetShiftFullDto>> AddWorkTruck(AddWorkerDto addWorkTruck);
    Task<ServiceResponse<List<Dispatcher>>> getDispatcherSelectOptions();

    }
}