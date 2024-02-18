namespace itms_v2.Server.Models
{
    public class Trailer {
        public int Id {get;set;}
        public string Plate{get;set;} = "AAA001";
        public bool ADR {get;set;} = true;
        public bool Traffic {get;set;} = true;
        public string owner {get;set;} = "SDS";
        public bool Active{get;set;} = true;
        public bool Loaded{get;set;} = false;
        public string Goods{get;set;} = String.Empty;
        public bool Standby{get;set;} = false;
        public string ParkigLocation{get;set;} = "Göd";
    }
}