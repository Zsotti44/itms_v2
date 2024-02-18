namespace itms_v2.Server.Models.Dtos.Worker
{
    public class GetWorkerDto
    {
        public int Id {get;set;}
        public Truck truck{get;set;}
        public Trailer trailer{get;set;}
        public TruckDriver driver{get;set;}
    }
}