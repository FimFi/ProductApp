
using System;
using System.Collections.Generic;
using ProductApp.Core.Entity;
using System.Text;

namespace ProductApp.Core.DomainServices
{
    public interface IProductRepository
    {
        IEnumerable<Product> ReadAll();
        Product Create(Product product);
        Product ReadById(int id);
        Product Update(Product productUpdate);
        Product Delete(int id);
    }
}
