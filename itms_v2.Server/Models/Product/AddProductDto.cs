namespace itms_v2.Server.Models.Dtos
{
    public class AddProductDto
    {
        public string Name {get;set;} = String.Empty;
        public ProductCategory Category{get;set;}
        public int Goods_pal{get;set;} = 0;
        public int weight{get;set;} = 0;
    }
}