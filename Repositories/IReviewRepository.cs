using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductReviewAuthentication.Models;

namespace ProductReviewAuthentication.Repositories
{
    public interface IReviewRepository
    {
        public Review AddReview(Review review);

        public Review FindUserById(Guid id);

        public List<Review> FindByProductId(Guid productId);

        public Review UpdateReview(Review review);

        public void Delete(Guid id);

        public List<Review> GetReviews(Guid userId);

        public List<Review> GetReviewsProduct(Guid productId);
    }
}
