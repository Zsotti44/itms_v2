using itms_v2.Server.Models.Dtos;

namespace itms_v2.Server.Models.Dtos
{
    public class AddShiftDto
    {
        public List<AddWorkerDto> trucks{get;set;}
        public int dispatcherId{get;set;}
        public DateTime startDateTime{get;set;}
        public string shift_id {get;set;}
    }
}