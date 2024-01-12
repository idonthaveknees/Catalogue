using Catalogue.Server.Models;

namespace Catalogue.Server.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Code = "FR001", Name = "Apple", Price = 0.99M },
                new Product { Id = 2, Code = "FR002", Name = "Banana", Price = 1.99M },
            };
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public void AddProduct(Product product)
        {
            product.Id = _products.Any() ? _products.Count + 1 : 1;
            _products.Add(product);
        }
    }

    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        void AddProduct(Product product);
    }
}
