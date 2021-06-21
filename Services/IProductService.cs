using Microsoft.AspNetCore.Mvc.Rendering;
using ProductReviewAuthentication.Models;
using ProductReviewAuthentication.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace ProductReviewAuthentication.Services
{
    public interface IProductService
    {
        public Product AddProduct(string name, string description, Guid userId);
     
        public void Delete(Guid id);

        public Product FindUserById(Guid id);

        public List<ProductViewModel> GetProducts(Guid userId);

        public List<Product> GetReviewProducts(Guid userId);

        public Product UpdateProduct(UpdateProductViewModel model);

        public IEnumerable<SelectListItem> GetProductList(Guid userId);

        public IEnumerable<SelectListItem> GetReviewProductList(Guid userId);  
    }
}
