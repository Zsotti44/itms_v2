namespace itms_v2.Server.Models.Dtos
{
    public class GetTruckDto
    {
        public int Id {get;set;}
        public string Plate{get;set;} = "AAA001";
        public bool Standalone{get;set;} = false;
        public bool ADR {get;set;} = true;
        public bool Traffic {get;set;} = true;
        public string owner {get;set;} = "SDS";
        public bool Active{get;set;} = true;
    }
}