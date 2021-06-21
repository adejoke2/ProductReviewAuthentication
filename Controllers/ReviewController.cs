using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductReviewAuthentication.Models;
using ProductReviewAuthentication.Models.ViewModels;
using ProductReviewAuthentication.Services;

namespace ProductReviewAuthentication.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public ReviewController(IReviewService reviewService, IProductService productService, IUserService userService)
        {
            _reviewService = reviewService;
            _productService = productService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index(ProductIndexViewModel model)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            List<ProductIndexViewModel> productIndexVM = new List<ProductIndexViewModel>();

            var reviews = _reviewService.GetReviews(userId);

            foreach (var review in reviews)
            {
                ProductIndexViewModel productIndex = new ProductIndexViewModel
                {
                    Id = review.Id,
                    Comment = review.Comment,
                    Ratings = review.Ratings,
                    UserName = _userService.FindUserById(review.UserId).Name,
                    ProductName = _productService.FindUserById(review.ProductId).Name,
                };

                productIndexVM.Add(productIndex);
            }
            return View(productIndexVM);
        }

        [HttpGet]
        public IActionResult SelectUser(Guid userId)
        {
            ViewBag.users = _userService.GetUserList();
            // ViewBag.products = _productService.GetProductList(userId);
            var model = new SelectUserViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SelectUser(SelectUserViewModel model)
        {
            return RedirectToAction(nameof(Create), new { userId= model.UserId});
        }
        // [Authorize]
        // [HttpGet]
        // public IActionResult Create()
        // {
        //     Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

        //     User user = _userService.FindUserById(userId);

        //     if (user == null) return RedirectToAction(nameof(Index));

        //     ViewBag.products = _productService.GetProductList(userId);
        //     ViewBag.userId = user.Name;

        //     return View();
        // }

        // [HttpPost]
        // public IActionResult Create(CreateReviewViewModel model)
        // {
        //     var userId = model.UserId;

        //     User user = _userService.FindUserById(userId);

        //     if (user == null ) return RedirectToAction(nameof(Index));

        //     ViewBag.products = _productService.GetReviewProductList(userId);

        //     ViewBag.UserId = user.Name;
        //     return View(model);
        // }
        // [Authorize]
        // [HttpPost]
        // public IActionResult Create(CreateReviewViewModel model)
        // {
        //     Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

        //     _reviewService.AddReview(model);

        //     return RedirectToAction("Index");
        // }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            User user = _userService.FindUserById(userId);

            if (user == null) return RedirectToAction(nameof(Index));

            ViewBag.products = _productService.GetProductList(userId);
            ViewBag.userId = user.Name;

            return View();
        }


        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateReviewViewModel model)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            _reviewService.AddReview(model.Comment, model.Ratings, userId, model.ProductId);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SubmitReview(CreateReviewViewModel model)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            Console.WriteLine("user Id is : "+model.UserId);
            Console.WriteLine("product Id is : " + model.ProductId);
            _reviewService.AddReview(model.Comment, model.Ratings, userId, model.ProductId);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Detail(Guid id)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            User user = _userService.FindUserById(userId);

            ViewBag.userName = user.Name;

            // Product product = _productService.FindProductById(id);

            // ViewBag.productName = product.Name;
            var review = _reviewService.FindUserById(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }


        public IActionResult Update(Guid id)
        {
            var review = _reviewService.FindUserById(id);
            if (review == null)
            {
                return NotFound();
            }
            else
            {
                return View(review);
            }
        }

        [HttpPost]
        public IActionResult Update(UpdateReviewViewModel model)
        {

            _reviewService.UpdateReview(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            var review = _reviewService.FindUserById(id);
            if (review == null)
            {
                return NotFound();
            }
            _reviewService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}