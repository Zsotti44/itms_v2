namespace itms_v2.Server.Models
{
    public class Workticket
    {
        public int Id {get;set;}
        public User requester {get;set;}
        public DateTime request_dateTime{get;set;} = DateTime.Now;
        public DateTime start_datetime{get;set;} = DateTime.Now;
        public DateTime finish_dateTime{get;set;} = DateTime.Now;
        public WorkTruck truck{get;set;}
        public User dispatcher{get;set;}
        public Warehouse from {get;set;}
        public Warehouse to {get;set;}
        public Product product {get;set;}
        public int palQty{get;set;} = 0;
        public int goodsQty{get;set;}= 0;
        public bool priority{get;set;} = false;
        public bool preloading {get;set;} = false;
        public string lot{get;set;} = String.Empty;
    }
}