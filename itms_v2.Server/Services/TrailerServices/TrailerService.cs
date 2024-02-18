using itms_v2.Server.Models;
using itms_v2.Server.Models.Dtos;
using itms_v2.Server.Models.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace itms_v2.Server.Services.TrailerServices
{
    public class TrailerService : ITrailerService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public TrailerService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetTrailerDto>>> AddTrailer(AddTrailerDto newTrailer)
        {
            var serviceResponse = new ServiceResponse<List<GetTrailerDto>>();
            var trailer = _mapper.Map<Trailer>(newTrailer);
            _context.Trailers.Add(trailer);
            await _context.SaveChangesAsync();
            serviceResponse.Data =
                await _context.Trailers
                    .Select(t => _mapper.Map<GetTrailerDto>(t))
                    .ToListAsync();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetTrailerDto>>> EditTrailer(Trailer editTrailer)
        {
            var serviceResponse = new ServiceResponse<List<GetTrailerDto>>();
             var dbTrailers = await _context.Trailers
                .FindAsync(editTrailer.Id);

            //dbTrailers.Plate = updatedTrailer.Plate; - NONO!
            dbTrailers.ADR = editTrailer.ADR;
            dbTrailers.owner = editTrailer.owner;
            dbTrailers.Active = editTrailer.Active;
            dbTrailers.Traffic = editTrailer.Traffic;
            dbTrailers.Loaded = editTrailer.Loaded;
            dbTrailers.Standby = editTrailer.Standby;
            dbTrailers.ParkigLocation = editTrailer.ParkigLocation;
            if(!editTrailer.Loaded) dbTrailers.Goods = "Üres"; 
            else dbTrailers.Goods = editTrailer.Goods;

            await _context.SaveChangesAsync();
            serviceResponse.Data =
                await _context.Trailers
                    .Select(t => _mapper.Map<GetTrailerDto>(t))
                    .ToListAsync();
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetTrailerDto>>> GetAllTrailers()
        {
            var serviceResponse = new ServiceResponse<List<GetTrailerDto>>();
            var dbTrailers = await _context.Trailers.ToListAsync();
            serviceResponse.Data = dbTrailers.Select(t => _mapper.Map<GetTrailerDto>(t)).ToList();
            return serviceResponse;
            }

        public async Task<ServiceResponse<GetTrailerDto>> GetTrailerById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTrailerDto>();
            var dbTrailers = await _context.Trailers
                .FirstOrDefaultAsync(t => t.Id == id);
            serviceResponse.Data = _mapper.Map<GetTrailerDto>(dbTrailers);
            return serviceResponse;
        }
         public async Task<ServiceResponse<List<TrailerSelectOptionsDto>>> GetTrailerSelectOptions(){
            var serviceResponse = new ServiceResponse<List<TrailerSelectOptionsDto>>();
            serviceResponse.Data =  await _context.Trailers.Where(t => t.Active).Select(t => new TrailerSelectOptionsDto{
                Id = t.Id,
                Plate = t.Plate
            }).ToListAsync();
            return serviceResponse;
         }
    }
}