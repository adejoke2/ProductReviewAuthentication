using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewAuthentication.Models
{
    public class User : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, MaxLength(6)]
        public string Gender { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string HashSalt { get; set; }

        public List<Product> Product { get; set; } = new List<Product>();

        public List<Review> Review { get; set; } = new List<Review>();
    }
}
