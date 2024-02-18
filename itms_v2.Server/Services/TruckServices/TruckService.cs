using itms_v2.Server.Models.ResponseModel;
using itms_v2.Server.Models;
using Microsoft.EntityFrameworkCore;
using itms_v2.Server.Models.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace itms_v2.Server.Services
{
    public class TruckService : ITruckService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public TruckService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetTruckDto>>> AddTruck(AddTruckDto newTruck)
        {
            var serviceResponse = new ServiceResponse<List<GetTruckDto>>();
            var truck = _mapper.Map<Truck>(newTruck);
            _context.Trucks.Add(truck);
            await _context.SaveChangesAsync();
            serviceResponse.Data =
                await _context.Trucks
                    .Select(t => _mapper.Map<GetTruckDto>(t))
                    .ToListAsync();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetTruckDto>>> EditTruck(Truck updatedTruck)
        {
            var serviceResponse = new ServiceResponse<List<GetTruckDto>>();
            var dbTrucks = await _context.Trucks
                .FindAsync(updatedTruck.Id);

            //dbTrucks.Plate = updatedTruck.Plate; - NONO!
            dbTrucks.ADR = updatedTruck.ADR;
            dbTrucks.owner = updatedTruck.owner;
            dbTrucks.Active = updatedTruck.Active;
            dbTrucks.Traffic = updatedTruck.Traffic;
            dbTrucks.Standalone = updatedTruck.Standalone;

            await _context.SaveChangesAsync();
            serviceResponse.Data =
                await _context.Trucks
                    .Select(t => _mapper.Map<GetTruckDto>(t))
                    .ToListAsync();
            return serviceResponse;
        }


          /*public async Task<ServiceResponse<List<GetTruckDto>>> DeleteTruck(int id){
            var serviceResponse = new ServiceResponse<List<GetTruckDto>>();
            var dbTrucks = await _context.Trucks
                .FindAsync(id);
            if(dbTrucks is null) {
                serviceResponse.Success = false;
                serviceResponse.Message = "Truck not found";
            }
            _context.Trucks.Remove(dbTrucks);
            await _context.SaveChangesAsync();
            serviceResponse.Data =
                await _context.Trucks
                    .Select(t => _mapper.Map<GetTruckDto>(t))
                    .ToListAsync();
            return serviceResponse;
        }*/

        public async Task<ServiceResponse<List<GetTruckDto>>> GetAllTrucks()
        {
            var serviceResponse = new ServiceResponse<List<GetTruckDto>>();
            var dbTrucks = await _context.Trucks.ToListAsync();
            serviceResponse.Data = dbTrucks.Select(t => _mapper.Map<GetTruckDto>(t)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTruckDto>> GetTruckById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTruckDto>();
            var dbTrucks = await _context.Trucks
                .FirstOrDefaultAsync(t => t.Id == id);
            serviceResponse.Data = _mapper.Map<GetTruckDto>(dbTrucks);
            return serviceResponse;
        }
         public async Task<ServiceResponse<List<TruckSelectOptionsDto>>> GetTruckSelectOptions(){
            var serviceResponse = new ServiceResponse<List<TruckSelectOptionsDto>>();
            serviceResponse.Data =  await _context.Trucks.Where(t => t.Active).Select(t => new TruckSelectOptionsDto{
                Id = t.Id,
                Plate = t.Plate
            }).ToListAsync();
            return serviceResponse;
         }

    }
}