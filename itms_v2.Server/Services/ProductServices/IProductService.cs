using itms_v2.Server.Models;
using itms_v2.Server.Models.Dtos;
using itms_v2.Server.Models.ResponseModel;

namespace itms_v2.Server.Services.ProductServices
{
    public interface IProductService
    {
    Task<ServiceResponse<List<Product>>> GetAllProducts();
    Task<ServiceResponse<List<Product>>> AddProduct(AddProductDto newDriver);
    Task<ServiceResponse<Product>> GetProductById(int id);   
    Task<ServiceResponse<List<Product>>> EditProduct(Product updatedProduct);
    Task<ServiceResponse<List<ProductSelectOptionsDto>>> GetProductSelectOptions();   
    }
}