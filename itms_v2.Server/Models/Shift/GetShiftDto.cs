namespace itms_v2.Server.Models.Dtos
{
    public class GetShiftDto
    {
        public int Id {get;set;}
        public int trucks{get;set;}
        public Dispatcher dispatcher{get;set;}
        public DateTime startDateTime{get;set;}
        public DateTime endDateTime{get;set;}
        public string shift_id{get;set;}
    }
}