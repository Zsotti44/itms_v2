using itms_v2.Server.Models;
using itms_v2.Server.Models.Dtos;
using itms_v2.Server.Models.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace itms_v2.Server.Services.ShiftServices
{
    public class ShiftService : IShiftService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ShiftService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetShiftDto>>> AddShift(AddShiftDto newShift)
        {
            var serviceResponse = new ServiceResponse<List<GetShiftDto>>();
            var shift = new Shift();
            shift.dispatcher = await _context.Users.FindAsync(newShift.dispatcherId);

            shift.trucks = [];
            DateTime myDate = DateTime.Now;

            shift.shift_id = DateTime.Now.ToString();
            _context.Shifts.Add(shift);

            await _context.SaveChangesAsync();
            serviceResponse.Data =
               await _context.Shifts
                    .Include(t => t.dispatcher)
                    .Include(t => t.trucks)
                    .OrderByDescending(t => t.Id)
                    .Select(t => _mapper.Map<GetShiftDto>(t))
                    .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetShiftDto>>> GetAllShifts()
        {
            var serviceResponse = new ServiceResponse<List<GetShiftDto>>();

            var db = await _context.Shifts
                    .Include(t => t.dispatcher)
                    .Include(t => t.trucks)
                    .OrderByDescending(t => t.Id)
                    .Select(t => _mapper.Map<GetShiftDto>(t))
                    .ToListAsync();
            serviceResponse.Data = db;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetShiftFullDto>> GetShiftById(int id)
        {
            var serviceResponse = new ServiceResponse<GetShiftFullDto>();
            var dbShifts = await _context.Shifts
                .Include(t => t.trucks)
                .Include(t => t.trucks).ThenInclude(t => t.truck)
                .Include(t => t.trucks).ThenInclude(t => t.driver)
                .Include(t => t.trucks).ThenInclude(t => t.trailer)
                .Include(t => t.dispatcher)
                .FirstOrDefaultAsync(t => t.Id == id);
            serviceResponse.Data = _mapper.Map<GetShiftFullDto>(dbShifts);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetShiftFullDto>> UpdateWorkTruckById(UpdateWorkTruckDto updateWorkTruck)
        {

            var dbWorkTruck = await _context.Workers
                   .FindAsync(updateWorkTruck.Id);

            dbWorkTruck.truck = await _context.Trucks.FindAsync(updateWorkTruck.truck);
            dbWorkTruck.trailer = await _context.Trailers.FindAsync(updateWorkTruck.trailer);
            dbWorkTruck.driver = await _context.TruckDrivers.FindAsync(updateWorkTruck.driver);

            await _context.SaveChangesAsync();
            var returnVal = await GetShiftById(updateWorkTruck.shiftid);
            return returnVal;
        }
        public async Task<ServiceResponse<GetShiftFullDto>> AddWorkTruck(AddWorkerDto addWorkTruck)
        {
            var shift = await _context.Shifts
                .Include(t => t.trucks)
                .Include(t => t.trucks).ThenInclude(t => t.truck)
                .Include(t => t.trucks).ThenInclude(t => t.driver)
                .Include(t => t.trucks).ThenInclude(t => t.trailer)
                .FirstOrDefaultAsync(t => t.Id == addWorkTruck.shiftid);

            WorkTruck wt = new WorkTruck();

            wt.truck = await _context.Trucks.FindAsync(addWorkTruck.truck);
            wt.driver = await _context.TruckDrivers.FindAsync(addWorkTruck.driver);
            wt.trailer = await _context.Trailers.FindAsync(addWorkTruck.trailer);

            shift.trucks.Add(wt);

            await _context.SaveChangesAsync();
            var returnVal = await GetShiftById(addWorkTruck.shiftid);
            return returnVal;
        }

        public async Task<ServiceResponse<List<Dispatcher>>> getDispatcherSelectOptions()
        {
            var serviceResponse = new ServiceResponse<List<Dispatcher>>();
            serviceResponse.Data = await _context.Users.Where(d=> d.dispatcher == true).Select(d => _mapper.Map<Dispatcher>(d)).ToListAsync();
            return serviceResponse;
        }
    }
}