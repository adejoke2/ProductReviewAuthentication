using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewAuthentication.Models
{
    public class Product : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public Guid UserId {get; set;}

        [Required, MaxLength(250)]
        public string Description { get; set; }

         public Guid ProductId {get; set;}

        public User User { get; set; }

        public List<Review> Review { get; set; } = new List<Review>();
    }
}
