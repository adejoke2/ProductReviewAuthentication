using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductReviewAuthentication.Models;
using ProductReviewAuthentication.Models.ViewModels;
using ProductReviewAuthentication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProductReviewAuthentication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        private readonly IUserService _userService;

        public ProductController(IProductService productService,IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index(ProductViewModel model)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var products = _productService.GetProducts(userId);
            return View(products);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {
            Guid userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            Product p = _productService.AddProduct(model.Name, model.Description, userId);

            return RedirectToAction("Index");
        }
        public IActionResult Update(Guid id)
        {
            var product = _productService.FindUserById(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return View(product);
            }
        }
        [HttpPost]
        public IActionResult Update(UpdateProductViewModel model)
        {
            _productService.UpdateProduct(model);
            return RedirectToAction("Index");
        }
          public IActionResult Delete(Guid id)
        {
            var product = _productService.FindUserById(id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
