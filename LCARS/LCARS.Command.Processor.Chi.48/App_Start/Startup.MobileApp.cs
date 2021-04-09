using System.Data.Entity;
using System.Web.Http;
using LCARS.Command.Processor.Chi._48.Migrations;
using LCARS.Command.Processor.Chi._48.Models;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using Microsoft.Azure.Mobile.Server.Tables.Config;
using Owin;

namespace LCARS.Command.Processor.Chi._48
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .AddTables(new MobileAppTableConfiguration().MapTableControllers().AddEntityFramework())
                .ApplyTo(config);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MobileDatabankContext, Configuration>());

            var settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

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