using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Sys.Data;
using Sys.Entity;

namespace Sys.WebApi.Infrastructure
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        {
        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<AppDbContext>();
            var appUserManager = new AppUserManager(new UserStore<AppUser>(appDbContext));

            return appUserManager;
        }
    }
}