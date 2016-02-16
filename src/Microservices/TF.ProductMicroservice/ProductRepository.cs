using System;
using System.Collections.Generic;
using System.Linq;

namespace TF.ProductMicroservice
{
    class ProductRepository : IProductRepository
    {

        private ProductContext productContext = new ProductContext();

        public IEnumerable<Product> Get()
        {
            List<Product> result = null;
            result = productContext.Products.ToList();
            if (result == null)
            {
                return new List<Product>();
            }
            return result;
        }

        public Product Get(Guid productId)
        {
            Product result = null;
            result = productContext.Products.First(p => p.Id == productId);
            return result;
        }

        public Product Save(Product product)
        {
            if (product.Id == Guid.Empty)
            {
                return Create(product);
            }
            else
            {
                return Update(product);
            }
        }

        public void Delete(Guid productId)
        {
            Product toDel = null;
            toDel = productContext.Products.First(p => p.Id == productId);
            if (toDel != null)
            {
                productContext.Products.Remove(toDel);
                productContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private Product Update(Product product)
        {
            using (var productContext = new ProductContext())
            {
                productContext.Products.Attach(product);
                productContext.SaveChanges();
                return product;
            }
        }

        private Product Create(Product product)
        {
            using (var productContext = new ProductContext())
            {
                var result = productContext.Products.Add(product);
                productContext.SaveChanges();
                return productContext.Products.Add(result);
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    productContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
