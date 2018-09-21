using Microsoft.AspNet.Identity.EntityFramework;
using Paulo.Infra.Identity.Models;
using System;
using System.Data.Entity;

namespace Paulo.Infra.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole,
                                        int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext()
            : base("AppDbContext")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
