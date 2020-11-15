using Microsoft.EntityFrameworkCore;
using ProductApp.Core.DomainServices;
using ProductApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductApp.Infrastructure.SQLLite.Data.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private ProductAppLiteContext _ctx;
        public ProductRepository(ProductAppLiteContext ctx)
        {
            _ctx = ctx;
        }

        public Product Create(Product product)
        {
            _ctx.Attach(product).State = EntityState.Added;
            _ctx.SaveChanges();
            return product;
        }

        public Product Delete(int id)
        {
            var productRemoved = _ctx.Remove(new Product { Id = id }).Entity;
            _ctx.SaveChanges();
            return productRemoved;
        }

        public IEnumerable<Product> ReadAll()
        {
            return _ctx.Products;
        }

        public Product ReadById(int id)
        {
            return _ctx.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product Update(Product productUpdate)
        {
            _ctx.Attach(productUpdate).State = EntityState.Modified;
            _ctx.Entry(productUpdate).Reference(p => p.Name).IsModified = true;
            _ctx.SaveChanges();
            return productUpdate;
        }
    }
}
