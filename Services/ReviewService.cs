using ProductReviewAuthentication.Models;
using ProductReviewAuthentication.Models.ViewModels;
using ProductReviewAuthentication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewAuthentication.Services
{
    public class ReviewService : IReviewService
    {
         public readonly IReviewRepository _reviewRepository;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public ReviewService(IProductService productService, IUserService userService, IReviewRepository reviewRepository)
        {
            _productService = productService;

            _userService = userService;

            _reviewRepository = reviewRepository;
        }


        public Review AddReview(string comment, double ratings, Guid userId, Guid productId)
        {
            var review = new Review
            {
                 Id = Guid.NewGuid(),
                Comment = comment,
                Ratings = ratings,
                CreatedAt = DateTime.Now,
                User = _userService.FindUserById(userId),
                Product = _productService.FindUserById(productId)
            };
             _reviewRepository.AddReview(review);

            return review;
        }

       
        public void Delete(Guid id)
        {
            _reviewRepository.Delete(id);
        }

        public Review FindUserById(Guid id)
        {
            return _reviewRepository.FindUserById(id);
        }

        public List<Review> FindByProductId (Guid productId)
        {
            return _reviewRepository.FindByProductId(productId);
        }
        public List<ReviewViewModel> GetReviews(Guid userId)
        {
            var reviews = _reviewRepository.GetReviews(userId).Select(r => new ReviewViewModel
            {
                Id = r.Id,
                Comment = r.Comment,
                Ratings = r.Ratings,
                UserId = r.UserId,
                ProductId = r.ProductId
            }).ToList();

            return reviews;
        }
        public List<ProductIndexViewModel> GetReviewsProduct(Guid productId)
        {
            var reviews = _reviewRepository.GetReviewsProduct(productId).Select(r => new ProductIndexViewModel
            {
                Id = r.Id,
                Comment = r.Comment,
                Ratings = r.Ratings,
                UserId = r.UserId,
                ProductId = r.ProductId,
                UserName = _userService.FindUserById(r.UserId).Name,
                ProductName = _productService.FindUserById(r.ProductId).Name,
            }).ToList();
            return reviews;
        }

        public Review UpdateReview(UpdateReviewViewModel model)
        {
            var review = _reviewRepository.FindUserById(model.Id);
            review.Comment = model.Comment;
            review.Ratings = model.Ratings;
            return _reviewRepository.UpdateReview(review);
        }

    }
}
