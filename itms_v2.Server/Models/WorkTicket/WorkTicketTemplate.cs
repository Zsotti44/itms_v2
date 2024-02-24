namespace itms_v2.Server.Models
{
    public class WorkticketTemplate
    {
        public int Id {get;set;}
        public string name {get;set;}
        public Warehouse from {get;set;}
        public Warehouse to {get;set;}
        public Product product {get;set;}
        public int palQty{get;set;} = 0;
        public int goodsQty{get;set;}= 0;
        public string lot{get;set;} = String.Empty;
    }
}