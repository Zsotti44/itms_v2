namespace itms_v2.Server.Models.Dtos
{
    public class AddTrailerDto
    {
        public string Plate{get;set;} = "AAA001";
        public bool ADR {get;set;} = true;
        public bool Traffic {get;set;} = true;
        public string owner {get;set;} = "SDS";
        public bool Standby{get;set;} = false;
        public string ParkigLocation{get;set;} = "Göd";
    }
}