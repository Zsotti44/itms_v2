namespace itms_v2.Server.Models
{
    public class Product
    {
        public int Id {get;set;}
        public string Name {get;set;} = String.Empty;
        public ProductCategory Category{get;set;}
        public int Goods_pal{get;set;} = 0;
        public int Weight{get;set;} = 0;
        public DateTime Registered_date{get;set;}  = DateTime.Now;
        public DateTime Last_modify_date{get;set;} = DateTime.Now;
        public User Last_modify_user{get;set;}

    }
}