using itms_v2.Server.Models;
using itms_v2.Server.Models.Dtos;
using itms_v2.Server.Models.ResponseModel;
using Microsoft.EntityFrameworkCore;
namespace itms_v2.Server.Services.TruckDriverServices
{
    public class TruckDriverService : ITruckDriverService
    {

        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public TruckDriverService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetTruckDriverDto>>> AddTruckDriver(AddTruckDriverDto newDriver)
        {
            var serviceResponse = new ServiceResponse<List<GetTruckDriverDto>>();
            var driver = _mapper.Map<TruckDriver>(newDriver);
            _context.TruckDrivers.Add(driver);
            await _context.SaveChangesAsync();
            serviceResponse.Data =
                await _context.TruckDrivers
                    .Select(t => _mapper.Map<GetTruckDriverDto>(t))
                    .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTruckDriverDto>>> GetAllTruckDrivers()
        {
            var serviceResponse = new ServiceResponse<List<GetTruckDriverDto>>();
            var driver = await _context.TruckDrivers.ToListAsync();
            serviceResponse.Data = driver.Select(t => _mapper.Map<GetTruckDriverDto>(t)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTruckDriverDto>> GetTruckDriverById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTruckDriverDto>();
            var driver = await _context.TruckDrivers
                .FirstOrDefaultAsync(t => t.Id == id);
            serviceResponse.Data = _mapper.Map<GetTruckDriverDto>(driver);
            return serviceResponse;        
        }
        public async Task<ServiceResponse<List<GetTruckDriverDto>>> EditTruckDriver(TruckDriver updatedTruckDriver)
        {
            var serviceResponse = new ServiceResponse<List<GetTruckDriverDto>>();
            var dbTruckDrivers = await _context.TruckDrivers
                .FindAsync(updatedTruckDriver.Id);

            //dbTrucks.name = updatedTruckDriver.name; - NONO!
            dbTruckDrivers.ADR = updatedTruckDriver.ADR;
            dbTruckDrivers.Active = updatedTruckDriver.Active;
            dbTruckDrivers.Mobile = updatedTruckDriver.Mobile;

            await _context.SaveChangesAsync();
            serviceResponse.Data =
                await _context.TruckDrivers
                    .Select(t => _mapper.Map<GetTruckDriverDto>(t))
                    .ToListAsync();
            return serviceResponse;
        }
         public async Task<ServiceResponse<List<TruckDriverSelectOptionsDto>>> GetTruckDriverSelectOptions(){
            var serviceResponse = new ServiceResponse<List<TruckDriverSelectOptionsDto>>();
            serviceResponse.Data =  await _context.TruckDrivers.Where(t => t.Active).Select(t => new TruckDriverSelectOptionsDto{
                Id = t.Id,
                Name = t.Name
            }).ToListAsync();
            return serviceResponse;
         }
    }
}