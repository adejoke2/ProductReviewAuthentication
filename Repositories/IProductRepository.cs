using ProductReviewAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewAuthentication.Repositories
{
    public interface IProductRepository
    {
        public Product AddProduct(Product product);

        public Product FindUserById(Guid id);

        public Product UpdateProduct(Product product);

        public void Delete(Guid id);

        public List<Product> GetProducts(Guid UserId);

        public List<Product> GetReviewProducts(Guid userId);

        // public List<Product> GetTotalReview(Guid userId);

        // public List<Product> GetTotalProduct(Guid userId);  
           
    }
}
