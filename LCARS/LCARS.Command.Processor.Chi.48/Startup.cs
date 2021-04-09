using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LCARS.Command.Processor.Chi._48.Startup))]

namespace LCARS.Command.Processor.Chi._48
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureMobileApp(app);
        }
    }
}
