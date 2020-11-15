using ProductApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Core.ApplicationServices
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product UpdateProduct(Product updateProduct);
        Product FindProductById(int Id);
        Product DeleteProduct(int id);
        Product CreateProduct(Product product);

    }
}
