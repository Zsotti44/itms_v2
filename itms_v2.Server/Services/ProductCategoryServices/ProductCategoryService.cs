using itms_v2.Server.Models;
using itms_v2.Server.Models.Dtos;
using itms_v2.Server.Models.ResponseModel;

namespace itms_v2.Server.Services.ProductCategoryServices
{
    public class ProductCategoryService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public ProductCategoryService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<ProductCategory>>> GetAllProductCategorys()
        {
            var serviceResponse = new ServiceResponse<List<ProductCategory>>();

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<ProductCategory>>> AddProductCategory(AddProductCategoryDto newDriver)
        {
            var serviceResponse = new ServiceResponse<List<ProductCategory>>();

            return serviceResponse;
        }
        public async Task<ServiceResponse<ProductCategory>> GetProductCategoryById(int id)
        {
            var serviceResponse = new ServiceResponse<ProductCategory>();

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<ProductCategory>>> EditProductCategory(ProductCategory updatedProductCategory)
        {
            var serviceResponse = new ServiceResponse<List<ProductCategory>>();

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<ProductCategorySelectOptionsDto>>> GetProductCategorySelectOptions()
        {
            var serviceResponse = new ServiceResponse<List<ProductCategorySelectOptionsDto>>();

            return serviceResponse;
        }
    }
}