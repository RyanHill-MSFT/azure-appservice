using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LCARS.Interfaces.Console.Desk.Chi.Startup))]
namespace LCARS.Interfaces.Console.Desk.Chi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
