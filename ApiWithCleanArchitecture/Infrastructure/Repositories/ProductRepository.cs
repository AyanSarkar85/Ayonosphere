using Domain.Interfaces;
using Domain.Models;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly ProductDbContext _dbContext;
        
        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product? GetProductByID(int productId)
        {
            return _dbContext.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _dbContext.Products.Add(product);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            Save();
        }

        public void DeleteProduct(int ProductId)
        {
            var product = _dbContext.Products.Find(ProductId);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                Save();
            }
        }        
    }
}
