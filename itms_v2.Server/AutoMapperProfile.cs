using itms_v2.Server.Models;
using itms_v2.Server.Models.Dtos;

namespace itms_v2.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Truck,GetTruckDto>();
            CreateMap<AddTruckDto,Truck>();
            CreateMap<AddTrailerDto,Trailer>();
            CreateMap<Trailer,GetTrailerDto>();
            CreateMap<TruckDriver,GetTruckDriverDto>();
            CreateMap<AddTruckDriverDto,TruckDriver>();
            CreateMap<AddShiftDto,Shift>();
            CreateMap<Shift,GetShiftDto>()
                .ForMember(t => t.trucks,opt => opt.MapFrom(src => src.trucks.Count()));
            CreateMap<Shift,GetShiftFullDto>();
            CreateMap<User,Dispatcher>();
        }
    }
}