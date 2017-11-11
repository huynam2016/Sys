using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Sys.WebApi.Providers;
using Sys.Data;
using Sys.WebApi.Infrastructure;

[assembly: OwinStartup(typeof(Sys.WebApi.Startup))]

namespace Sys.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigureOAuth(app);
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(AppDbContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AppOAuthProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
