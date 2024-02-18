using itms_v2.Server.Models;
using itms_v2.Server.Models.Dtos;
using itms_v2.Server.Models.ResponseModel;

namespace itms_v2.Server.Services.TruckDriverServices
{
    public interface ITruckDriverService
    {
    Task<ServiceResponse<List<GetTruckDriverDto>>> GetAllTruckDrivers();
    Task<ServiceResponse<List<GetTruckDriverDto>>> AddTruckDriver(AddTruckDriverDto newDriver);
    Task<ServiceResponse<GetTruckDriverDto>> GetTruckDriverById(int id);   
    Task<ServiceResponse<List<GetTruckDriverDto>>> EditTruckDriver(TruckDriver updatedTruckDriver);
    Task<ServiceResponse<List<TruckDriverSelectOptionsDto>>> GetTruckDriverSelectOptions();   

    }
}