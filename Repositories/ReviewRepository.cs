using Microsoft.EntityFrameworkCore;
using ProductReviewAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewAuthentication.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ProductAuthenticationDbContext _dbContext;

        public ReviewRepository(ProductAuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Review AddReview(Review review)
        {
            _dbContext.Reviews.Add(review);
            _dbContext.SaveChanges();
            return review;
        }

        public Review FindUserById(Guid id)
        {
            return _dbContext.Reviews.Find(id);
        }

        public List<Review> FindByProductId(Guid productId)
        {
            return _dbContext.Reviews.Where(review => review.ProductId == productId).ToList();
        }

        public Review UpdateReview(Review review)
        {
            _dbContext.Reviews.Update(review);
            _dbContext.SaveChanges();
            return review;
        }

        public void Delete(Guid id)
        {
            var review = FindUserById(id);

            if (review != null)
            {
                _dbContext.Reviews.Remove(review);
                _dbContext.SaveChanges();
            }
        }

        public List<Review> GetReviews(Guid userId)
        {
            return _dbContext.Reviews.Include(r => r.Product).Include(r => r.User).ToList();
        }

        public List<Review> GetReviewsProduct(Guid productId)
        {
            return _dbContext.Reviews.Where(review=> review.ProductId == productId).ToList();
        }

    }
}
