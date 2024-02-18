using System.Text.Json.Serialization;
using itms_v2.Server.Models.Dtos;

namespace itms_v2.Server.Models
{
    public class WorkTruck
    {
        public int Id {get;set;}
        public Truck truck{get;set;} = null;
        public Trailer trailer{get;set;} = null;
        public TruckDriver driver{get;set;} = null;
        public int price{get;set;} = 435;
        public bool working{get;set;} = false;
    }
}