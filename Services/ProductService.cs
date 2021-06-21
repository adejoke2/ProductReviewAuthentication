using Microsoft.AspNetCore.Mvc.Rendering;
using ProductReviewAuthentication.Models;
using ProductReviewAuthentication.Models.ViewModels;
using ProductReviewAuthentication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewAuthentication.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserService _userService;

        private readonly IUserRepository _userRepository;

        private readonly IReviewRepository _reviewRepository;

        public ProductService(IProductRepository productRepository, IUserService userService)
        {
            _productRepository = productRepository;
            _userService = userService;
        }
        
        public Product AddProduct(string name, string description, Guid userId)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                CreatedAt = DateTime.Now,
                User = _userService.FindUserById(userId)
            };

            _productRepository.AddProduct(product);

            return product;
        }

        public void Delete(Guid id)
        {
            _productRepository.Delete(id);
        }
        public Product FindUserById(Guid id)
        {
            return _productRepository.FindUserById(id);
        }

        public double GetAverageRating(Guid productId)
        {
           var reviews = _reviewRepository.FindByProductId(productId);
           double sum = 0;
           if (reviews.Count == 0) return 0;
           foreach (var review in reviews)
           {
               sum += review.Ratings;
           }
           double totalaverage = sum / reviews.Count;
           return totalaverage;
        }

    //    public IEnumerable<SelectListItem> GetProductList(Guid userId)
    //     {
    //         return GetProducts(userId).Select(c => new SelectListItem()
    //         {
    //             Text = c.Name,
    //             Value = c.Id.ToString()
    //         });
    //     }

        public IEnumerable<SelectListItem> GetProductList(Guid userId)
        {
            return GetProducts(userId).Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });    
        }
        public List<ProductViewModel> GetProducts(Guid userId)
        {
           var products = _productRepository.GetProducts(userId).Select(p => new ProductViewModel
           {
               Id = p.Id,
               Name = p.Name,
               Description = p.Description,
               UserName = _userService.FindUserById(p.UserId).Name,
               AverageRating = GetAverageRating(p.Id)
           }).ToList();

           return products;
        }
        public IEnumerable<SelectListItem> GetReviewProductList(Guid userId)
        {
            return GetReviewProducts(userId).Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
        }
        public List<Product> GetReviewProducts(Guid userId)
        {
           var products = _productRepository.GetReviewProducts(userId);
           return products;
        }
        public Product UpdateProduct(UpdateProductViewModel model)
        {
           var product = _productRepository.FindUserById(model.Id);
           product.Name = model.Name;
           product.Description = model.Description;

           return _productRepository.UpdateProduct(product);
        }
    }
}
