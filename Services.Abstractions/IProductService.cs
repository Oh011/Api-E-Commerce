using Shared;

namespace Services.Abstractions
{
    public interface IProductService
    {


        //Get all Products , brands , types , product by Id


        public Task<IEnumerable<ProductResultDto>> GetAllProductsAsync();



        public Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();



        public Task<IEnumerable<TypeResultDto>> GetAllTypesAsync();




        public Task<ProductResultDto> GetProductById(int id);


    }
}
