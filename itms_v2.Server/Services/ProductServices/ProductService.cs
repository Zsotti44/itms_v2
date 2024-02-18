using itms_v2.Server.Models;
using itms_v2.Server.Models.Dtos;
using itms_v2.Server.Models.ResponseModel;

namespace itms_v2.Server.Services.ProductServices
{
    public class ProductService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public ProductService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Product>>> GetAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<Product>>();

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<Product>>> AddProduct(AddProductDto newDriver)
        {
            var serviceResponse = new ServiceResponse<List<Product>>();

            return serviceResponse;
        }
        public async Task<ServiceResponse<Product>> GetProductById(int id)
        {
            var serviceResponse = new ServiceResponse<Product>();

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<Product>>> EditProduct(Product updatedProduct)
        {
            var serviceResponse = new ServiceResponse<List<Product>>();

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<ProductSelectOptionsDto>>> GetProductSelectOptions()
        {
            var serviceResponse = new ServiceResponse<List<ProductSelectOptionsDto>>();

            return serviceResponse;
        }
    }
}