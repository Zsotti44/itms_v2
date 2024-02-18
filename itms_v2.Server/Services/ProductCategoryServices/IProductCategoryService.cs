using itms_v2.Server.Models;
using itms_v2.Server.Models.Dtos;
using itms_v2.Server.Models.ResponseModel;

namespace itms_v2.Server.Services.ProductCategoryServices
{
    public interface IProductCategoryService
    {
    Task<ServiceResponse<List<ProductCategory>>> GetAllProductCategorys();
    Task<ServiceResponse<List<ProductCategory>>> AddProductCategory(AddProductCategoryDto newDriver);
    Task<ServiceResponse<ProductCategory>> GetProductCategoryById(int id);   
    Task<ServiceResponse<List<ProductCategory>>> EditProductCategory(ProductCategory updatedProductCategory);
    Task<ServiceResponse<List<ProductCategorySelectOptionsDto>>> GetProductCategorySelectOptions();   
    }
}