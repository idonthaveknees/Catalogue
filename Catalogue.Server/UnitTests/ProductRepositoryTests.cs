using Catalogue.Server.Models;
using Catalogue.Server.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalogue.Server.UnitTests
{
    [TestClass]
    public class ProductRepositoryTests
    {
        [TestMethod]
        public void AddProduct_ShouldIncreaseProductCount()
        {
            // Arrange
            var repository = new ProductRepository();
            var initialProductCount = repository.GetAll().Count();

            // Act
            var newProduct = new Product { Id = 0, Code = "ABC123", Name = "TestProduct", Price = 9.99M };
            repository.AddProduct(newProduct); 

            // Assert
            var finalProductCount = repository.GetAll().Count();
            Assert.AreEqual(initialProductCount + 1, finalProductCount, "Product count should increase by 1");
        }
    }
}
