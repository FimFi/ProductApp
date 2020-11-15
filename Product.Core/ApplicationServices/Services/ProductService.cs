using ProductApp.Core.DomainServices;
using ProductApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductApp.Core.ApplicationServices.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        public ProductService(IProductRepository productRepository) 
        {
            _productRepo = productRepository;
        }
        public Product CreateProduct(Product product)
        {
            return _productRepo.Create(product);
        }

        public Product DeleteProduct(int id)
        {
            return _productRepo.Delete(id);
        }

        public Product FindProductById(int Id)
        {
            return _productRepo.ReadById(Id);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepo.ReadAll().ToList();
        }

        public Product NewProduct(string name, double price, string color, string type)
        {
            var product = new Product()
            {
                Name = name,
                Price = price,
                Type = type,
            };
            return product;
        }

        public Product UpdateProduct(Product updateProduct)
        {
            return _productRepo.Update(updateProduct);
        }
    }
}
