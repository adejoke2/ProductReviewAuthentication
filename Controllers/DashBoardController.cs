using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductReviewAuthentication.Models;
using ProductReviewAuthentication.Models.ViewModels;
using ProductReviewAuthentication.Services;
using System;
using System.Linq;
using System.Security.Claims;

namespace ProductReviewAuthentication.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        private readonly IProductService _productService;

        private readonly IReviewService _reviewService;

        private readonly IUserService _userService;

        public DashBoardController(IProductService productService, IReviewService reviewService, IUserService userService)
        {
            _productService = productService;

            _reviewService = reviewService;

            _userService = userService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index(ProductViewModel model)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var products = _productService.GetProducts(userId);
            return View(products);
        }
       [HttpGet]
        public IActionResult Detail(ProductViewModel model)
        {
            Console.WriteLine(model.Id);
            var review = _reviewService.GetReviewsProduct(model.Id); 
            if(review == null)
            {
                return NotFound();
            }
            return View(review);
        }
    }
}
