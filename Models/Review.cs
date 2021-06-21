using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewAuthentication.Models
{
    public class Review : BaseEntity
    {
        public User User { get; set; }

        public Guid UserId {get; set;}

        public Guid ProductId {get; set;}

        public Product Product { get; set; }

        [Required, MaxLength(250)]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Rate Us Here!")]
        [Range(1, 5)]
        public Double Ratings { get; set; }
    }
}
