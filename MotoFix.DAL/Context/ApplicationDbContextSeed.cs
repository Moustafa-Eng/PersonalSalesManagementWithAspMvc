using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MotoFix.DAL.Context
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<IdentityUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var User = new IdentityUser
                {
                    Email = "mustafakhaledmah@gmail.com",
                    UserName = "mustafakhaledmah"
                };

               await userManager.CreateAsync(User, "Pa$$w0rd");
            }   
            
        
        }
    }
}
