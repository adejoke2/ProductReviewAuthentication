using System;
using System.ComponentModel.DataAnnotations;

namespace ProductReviewAuthentication.Models.ViewModels
{
    public class ReviewViewModel :BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public string Comment { get; set; }

        public Double Ratings { get; set; }

        public string UserName { get; set; }

        public string ProductName { get; set; }
    }

    public class ProductIndexViewModel
    {
        public Guid Id { get; set; }

        public string Comment { get; set; }

        public Double Ratings { get; set; }

        public string UserName { get; set; }

        public string ProductName { get; set; }
        public Guid ProductId { get; internal set; }
        public Guid UserId { get; internal set; }
    }

    public class SelectUserViewModel
    {
        [Required(ErrorMessage = "You must fill out this field!")]
        [Display(Name = "User Name:")]
        public Guid UserId { get; set; }

    }

    public class CreateReviewViewModel
    {
        [Required(ErrorMessage = "You must fill out this field!")]
        [Display(Name = "User Name:")]
        public Guid UserId { get; set; }

       
        [Required(ErrorMessage = "You must fill out this field!")]
        [Display(Name = "Product Name:")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Please make a Comment!!")]
        [Display(Name = "Comment Section:")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Rate Us Here!")]
        [Range(1, 5)]
        public Double Ratings { get; set; }
    }
    public class UpdateReviewViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please make a Comment!!")]
        [Display(Name = "Comment Section:")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Rate Us Here!")]
        [Range(1, 5)]
        public Double Ratings { get; set; }
    }
    }
