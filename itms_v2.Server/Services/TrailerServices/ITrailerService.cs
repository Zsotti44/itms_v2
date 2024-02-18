using itms_v2.Server.Models;
using itms_v2.Server.Models.Dtos;
using itms_v2.Server.Models.ResponseModel;

namespace itms_v2.Server.Services.TrailerServices
{
    public interface ITrailerService
    {
         
    Task<ServiceResponse<List<GetTrailerDto>>> GetAllTrailers();
    Task<ServiceResponse<List<GetTrailerDto>>> AddTrailer(AddTrailerDto newTrailer);
    Task<ServiceResponse<List<GetTrailerDto>>> EditTrailer(Trailer editTrailer);
    Task<ServiceResponse<GetTrailerDto>> GetTrailerById(int id);   
    Task<ServiceResponse<List<TrailerSelectOptionsDto>>> GetTrailerSelectOptions();   

    }
}