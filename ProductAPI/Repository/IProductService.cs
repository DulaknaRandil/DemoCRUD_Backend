using ProductAPI.Model;

namespace ProductAPI.IService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAysnc();
        Task<Product>GetByIdAysnc(int id);
        Task<Product> CreateAsync(Product product);
        Task<bool>UpdateAysnc(int id ,Product product);
        Task<bool> DeleteAsync(int id);


    }
}
