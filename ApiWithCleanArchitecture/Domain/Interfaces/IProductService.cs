using Domain.Models;

namespace Domain.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();

        //Product GetProduct(int id);

        bool InsertNewProduct(Product product);

        bool UpdateProduct(Product product);

        bool DeleteProduct(int id);
    }
}
