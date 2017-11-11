using Microsoft.AspNet.Identity;
using Sys.Entity;
using Sys.WebApi.Infrastructure;
using Sys.WebApi.Models.User;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sys.WebApi.Controllers
{
    [RoutePrefix("Api/User")]
    public class UserController : BaseApiController
    {
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            return Ok(AppUserManager.Users.Select(s=> new UserView {Id = s.Id, Email = s.Email, UserName = s.UserName }).ToList());
        }
        [Route("GetById/{Id}")]
        public async Task<IHttpActionResult> GetById(string id)
        {
            var user = await AppUserManager.FindByIdAsync(id);
            if (user != null)
            {
                return Ok(new UserView { Email = user.Email, UserName = user.UserName, Id = user.Id});
            }
            return NotFound();
        }
        [Route("Create")]
        public async Task<IHttpActionResult> Create(UserView model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new AppUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };
            IdentityResult addUser = await this.AppUserManager.CreateAsync(user, model.Password);
            return Ok(model);
        }
        [Route("Update/{Id}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(UserView model, string id)
        {
            var user = await AppUserManager.FindByIdAsync(id);
            if (user != null )
            {
                user.Email = model.Email;
                AppUserManager.Update(user);
            }
            
            return Ok(new UserView { Email = user.Email, UserName = user.UserName, Id = user.Id });
        }
    }
}
