using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ProductReviewAuthentication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewAuthentication.Services
{
    public interface IUserService
    {
        public User LoginUser(string email, string password);

        public void RegisterUser(string email, string name, string gender, string password);

        public User FindUserById(Guid id);

        public IEnumerable<SelectListItem> GetUserList();

        public List<UserViewModel> GetUsers();
    }
}
