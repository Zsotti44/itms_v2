namespace itms_v2.Server.Models.Dtos
{
    public class GetTruckDriverDto
    {
        
        public int Id {get;set;}
        public string Name {get;set;} = "Anonymous";
        public string Mobile {get;set;} = "+3620000000";
        public bool ADR{get;set;}
        public bool Active{get;set;}
    }
}