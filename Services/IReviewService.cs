using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductReviewAuthentication.Models;
using ProductReviewAuthentication.Models.ViewModels;

namespace ProductReviewAuthentication.Services
{
    public interface IReviewService
    {
        public Review AddReview(string comment, double ratings, Guid userId, Guid productId);

        public void Delete(Guid id);

        public Review FindUserById(Guid id);

        public List<Review> FindByProductId(Guid productId);

        public List<ReviewViewModel> GetReviews(Guid userId);

        public Review UpdateReview(UpdateReviewViewModel model);

        public List<ProductIndexViewModel> GetReviewsProduct(Guid productId);
    }
}
