using Microsoft.EntityFrameworkCore;
using ProductReviewAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewAuthentication.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductAuthenticationDbContext _dbContext;

        public ProductRepository(ProductAuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public Product FindUserById(Guid id)
        {
            return _dbContext.Products.Find(id);
        }

        public Product UpdateProduct(Product product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return product;
        }

        public void Delete(Guid id)
        {
            var product = FindUserById(id);

            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
        }
           public List<Product> GetProductList(Guid userId)
        {
            return _dbContext.Products.Include(p => p.User).Where(product => product.User.Id != userId).ToList();
        }

        public List<Product> GetProducts(Guid userId)
        {
            return _dbContext.Products.Include(p => p.User).Where(p => p.User.Id == userId).ToList();
        }

        public List<Product> GetReviewProducts(Guid userId)
        {
            return _dbContext.Products.Where(product => product.User.Id != userId).ToList();
        }

        // public List<Product> GetTotalReview(Guid userId)
        // {
        //     return _dbContext.Product.Where(product == product.reviews == userId).count();
        // }
        // public List<Product> GetTotalProduct(Guid userId)
        // {
        //    return _dbContext.Product.Where(product == product.userId == productId).count();
        // }
    }
}
