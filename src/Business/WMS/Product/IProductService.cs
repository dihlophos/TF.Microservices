using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TF.Business.WMS.Product
{
    public interface IProductService
    {
        void Create(Product product);
        void Update(Product product);
        void Delete(Guid id);

        void AddChild(Guid productId, Guid childId);
        void DeleteChild(Guid productId, Guid childId);

        Product GetById(Guid id);   
    }
}
