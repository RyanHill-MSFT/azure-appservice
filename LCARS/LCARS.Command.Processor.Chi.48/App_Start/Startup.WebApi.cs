using System.Data.Entity;
using System.IdentityModel.Tokens;
using System.Web.Http;
using LCARS.Command.Processor.Chi._48.Migrations;
using LCARS.Command.Processor.Chi._48.Models;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;
using Swashbuckle.Application;

namespace LCARS.Command.Processor.Chi._48
{
    public partial class Startup
    {
        public static void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            app.UseMicrosoftAccountAuthentication();
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(new WindowsAzureActiveDirectoryBearerAuthenticationOptions
            {
                Tenant = settings["ida:Tenant"],
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = settings["ida:Audience"],
                    ValidateAudience = false
                }
            });

            config.MapHttpAttributeRoutes();
            config.EnableSwagger(c => c.SingleApiVersion("v1", "LCARS Command Processor Chi 4.8"))
                  .EnableSwaggerUi();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional });

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MobileDatabankContext, Configuration>());

            if (string.IsNullOrEmpty(settings.HostName))
            {
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                });
            }

            app.UseWebApi(config);
        }
    }
}