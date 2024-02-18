namespace itms_v2.Server.Models
{
    public class Shift {
        public int Id {get;set;}
        public List<WorkTruck> trucks{get;set;}
        public DateTime startDateTime{get;set;} = DateTime.Now;
        public DateTime endDateTime{get;set;} = DateTime.Now;
        public User dispatcher{get;set;}
        public string shift_id{get;set;} = String.Empty;
    }
}