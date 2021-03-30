using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server.Config;
using Microsoft.Azure.Mobile.Server.Tables.Config;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LCARS.Command.Processor.Chi._48.Startup))]

namespace LCARS.Command.Processor.Chi._48
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();
            new MobileAppConfiguration()
                .AddMobileAppHomeController()
                .MapApiControllers()
                .AddTables(new MobileAppTableConfiguration().MapTableControllers().AddEntityFramework())
                .ApplyTo(config);
            app.UseWebApi(config);
        }
    }
}
