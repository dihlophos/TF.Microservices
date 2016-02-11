using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF.Business.WMS
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductService : IProductService
    {
        public void Create(Product product) { throw new NotImplementedException(); }
        public void Update(Product product) { throw new NotImplementedException(); }
        public void Delete(Guid id) { throw new NotImplementedException(); }

        public void AddChild(Guid productId, Guid childId) { throw new NotImplementedException(); }
        public void DeleteChild(Guid productId, Guid childId) { throw new NotImplementedException(); }

        public Product GetById(Guid id) { throw new NotImplementedException(); }
    }
}
