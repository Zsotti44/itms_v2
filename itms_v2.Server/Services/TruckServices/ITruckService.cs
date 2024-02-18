using itms_v2.Server.Models.ResponseModel;
using itms_v2.Server.Models;
using itms_v2.Server.Models.Dtos;

namespace itms_v2.Server.Services
{
    public interface ITruckService
    {
    Task<ServiceResponse<List<GetTruckDto>>> GetAllTrucks();
    Task<ServiceResponse<List<GetTruckDto>>> AddTruck(AddTruckDto newTruck);
    Task<ServiceResponse<List<GetTruckDto>>> EditTruck(Truck updatedTruck);
   // Task<ServiceResponse<List<GetTruckDto>>> DeleteTruck(int id);
    Task<ServiceResponse<GetTruckDto>> GetTruckById(int id);   
    Task<ServiceResponse<List<TruckSelectOptionsDto>>> GetTruckSelectOptions();   
    }
}