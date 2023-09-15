using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
            return true;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetProducts();
        }

        /*public Product GetProduct(int id)
        {
            
        }*/

        public bool InsertNewProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
            return true;
        }

        public bool UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
            return true;
        }
    }
}