using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Sys.WebApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sys.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {


        private AppUserManager _AppUserManager = null;
        private AppRoleManager _AppRoleManager = null;
        protected AppUserManager AppUserManager
        {
            get
            {
                return _AppUserManager ?? Request.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
        protected AppRoleManager AppRoleManager
        {
            get
            {
                return _AppRoleManager ?? Request.GetOwinContext().GetUserManager<AppRoleManager>();
            }
        }


        public BaseApiController()
        {
        }


        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
