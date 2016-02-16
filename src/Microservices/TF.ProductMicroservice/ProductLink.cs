using System;

namespace TF.ProductMicroservice
{
    public class ProductLink
    {
        private static readonly string apiURI = "/api/products/"; // полную ссылку

        public string Name { get; set; }
        public string Type { get; set; }
        public Guid Id { get; set; }
        public string Link
        {
            get
            {
                return apiURI + this.Id.ToString();
            }
        }
    }
}
