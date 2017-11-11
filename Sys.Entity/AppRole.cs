using Microsoft.AspNet.Identity.EntityFramework;

namespace Sys.Entity
{
    public class AppRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
