using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Domain.Entities;

namespace Vein360.Application.Common.Helpers.PasswordHelper
{
    public class PasswordHelper
    {
        private static PasswordHasher<Vein360User> _passwordHasher => new PasswordHasher<Vein360User>();

        public static string HashPassword(Vein360User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public static PasswordVerificationResult VerifyPassword(Vein360User user, string password)
        {
            return _passwordHasher.VerifyHashedPassword(user, user.Password, password);
        }
    }
}
